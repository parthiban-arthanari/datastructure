using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class Test
    {
        public static Test Instance = new Test();
        HashSet<string> map = new HashSet<string>();
        string key;
        string keyboard;

        private void Read()
        {
            key = "423692";
            keyboard = "923857614";
        }

        public void Do()
        {
            Read();
            var val = GetCount(key, keyboard);
        }

        // private string CanAdd(string line)
        // {
        //     string[] arr = line.Split(' ');

        //     if(arr[8].Equals("200") && arr[5].Equals("\"GET") && arr[6].Contains(".gif", StringComparer.CurrentCultureIgnoreCase))
        //     {
        //         int index = arr[6].LastIndexOf("/");
        //         string file = arr[6].Substring(index +1);
        //         if(!map.Contains(file))
        //             return file;
        //     }

        //     return null;
        // }

        public int GetCount(string key, string keyboard)
        {
            int[] keys = new int[key.Length];
            int[,] keyboards = new int[3,3];

            for(int i =0; i< key.Length; i++)
            {
                keys[i] = Convert.ToInt32(key[i]);
            }
            
            int row =0;
            for(int i =0; i< 9; i++)
            {
                keyboards[row,0] = Convert.ToInt32(keyboard[i]);
                keyboards[row,1] = Convert.ToInt32(keyboard[i]);
                keyboards[row,2] = Convert.ToInt32(keyboard[i]);
                row++;
            }

            int time;

            for(int i=0 ; i<keys.Length; i++)
            {
                int k = keys[i];

                
            }

            return 0;
        }

        
    }
}