public class Q2
    {
        public static string[] Search(string[] data, string key)
        {
            Hashtable map = new Hashtable();            
            int lastIndex = 0, prevIndex = -1;

            while (lastIndex == (prevIndex + 1))
            {
                for(int i = 0; i < data.Length; i++)
                {
                    if(lastIndex >= data[i].Length)
                        continue;

                    prevIndex = lastIndex;
                    var substr = data[i].Substring(0, lastIndex + 1);
                    if (!map.Contains(substr)) 
                    {
                        List<string> l = new List<string>();
                        l.Add(data[i]);
                        map.Add(substr, l);
                    }
                    else 
                    {
                        List<string> l = map[substr] as List<string>;
                        l.Add(data[i]);
                    }
                }

                lastIndex++; 

            }

            var o = map[key];

            if(o == null)
                return null;

            return ((List<string>)o).ToArray();
            
        }
    }