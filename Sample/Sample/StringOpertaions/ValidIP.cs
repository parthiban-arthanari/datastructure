using System;

namespace Sample.StringOperations
{
    public class ValidIP
    {
        public static ValidIP Instance = new ValidIP();
        string _ip;

        private void Read()
        {
            _ip = "g:f:f:f:f:f:f:g";
        }

        public void Do()
        {
            Read();
            string result = Validate(_ip);
        }

        public string Validate(string ip)
        {
            string[] arr = ip.Split('.');

            if(arr.Length == 4)
                return ValidateIpv4(arr);
            
            arr = ip.Split(':');
            if(arr.Length == 8)
                return ValidateIpv6(arr);

            return "Neither";

        }

        private string ValidateIpv4(string[] arr)
        {
            bool valid = true;

            foreach(var str in arr)
            {
                int val = -1;
                Int32.TryParse(str, out val);

                if(val > 255 || val < 0 || str.Length > 3 || string.IsNullOrWhiteSpace(str))
                    valid = false;
                else
                {
                    if((val == 0 || str.StartsWith('0')) && str.Length > 1)
                        valid = false;
                }

                if(!valid)
                    break;
                
            }

            return valid ? "IPv4" : "Neither";
        }

        private string ValidateIpv6(string[] arr)
        {
            foreach(var str in arr)
            {
                int val = -1;
                Int32.TryParse(str, System.Globalization.NumberStyles.HexNumber, null, out val);

                if(val > 65535 || val < 0 || str.Length > 4 || string.IsNullOrWhiteSpace(str))
                    return "Neither";
                else
                {
                    if(val == 0)
                    {
                       foreach(var c in str)
                       {
                           if(!Uri.IsHexDigit(c))
                           {
                               return "Neither";
                           }
                       }
                    }
                }
            }

            return "IPv6";
        }
    }
}