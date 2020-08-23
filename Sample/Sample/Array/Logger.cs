using System.Collections.Generic;
using System;

namespace Sample.Array
{
    public class Logger 
    {
        Dictionary<string, int> logs;
        public Logger()
        {
            logs = new Dictionary<string, int>();
        }

        public bool ShouldPrintMessage(int timestamp, string message) 
        {
            if(logs.ContainsKey(message))
            {   
                bool exist = timestamp - logs[message] >= 10;
                if(exist)
                    logs[message] = timestamp;
                return exist;
            }
            
            logs.Add(message, timestamp);
            return true;
        }
        
    }
}
