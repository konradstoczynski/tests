using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            //implementation for g
            VehicleMake vehicleMake = new VehicleMake("Mercedes-Benz");


            //implementation for h
            VehicleModel vehicleModel = new VehicleModel(vehicleMake, "A180", 300000);

            Console.WriteLine("Complete");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// base class for IDs
    /// </summary>
    public abstract class Entity<T>
    {
        public T Id { get; set; }
    }

    /// <summary>
    /// examples of makes of vehicle are Mercedes-Benz, Audi, Toyota, etc
    /// </summary>
    public class VehicleMake : Entity<int>
    {
        public string Description { get; set; }

        public VehicleMake(string description)
        {
            if (!string.IsNullOrEmpty(description))
            {
                this.Description = description;
            }
            else
            {
                throw new ArgumentNullException(nameof(Description));
            }
        }
    }

    /// <summary>
    /// examples of vehicle models are A 180 avantgarde or Corolla 1.6 GLE
    /// </summary>
    public class VehicleModel : Entity<int>
    {
        public string Description { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
        public virtual IList<VehiclePrice> VehiclePrices { get; set; }

        public VehicleModel(VehicleMake vehicleMake, string description)
        {
            BaseConstructor(vehicleMake, description);
        }

        public VehicleModel(VehicleMake vehicleMake, string description, decimal currentYearPrice)
        {
            BaseConstructor(vehicleMake, description);

            if (VehiclePrices == null)
            {
                VehiclePrices = new List<VehiclePrice>();
            }

            var currentPrice = VehiclePrices.FirstOrDefault(p => p.Year == DateTime.Now.Year);
            if (currentPrice != null)
            {
                // update existing one
                currentPrice.Price = currentYearPrice;
            }
            else
            {
                // add current year price
                VehiclePrices.Add(new VehiclePrice
                {
                    Year = DateTime.Now.Year,
                    Price = currentYearPrice
                });
            }
        }

        private void BaseConstructor(VehicleMake vehicleMake, string description)
        {
            if (!string.IsNullOrEmpty(description))
            {
                this.Description = description;
            }
            else
            {
                throw new ArgumentNullException(nameof(Description));
            }

            this.VehicleMake = vehicleMake;
        }
    }

    /// <summary>
    /// This has the price or the vehicle for a given year
    /// </summary>
    public class VehiclePrice : Entity<Guid>
    {
        public int Year { get; set; }
        public decimal Price { get; set; }
    }

}