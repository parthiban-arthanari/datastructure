using System;
using System.Collections.Generic;

namespace Sample.Bit
{
    public class ReverseBits
    {
        public static ReverseBits Instance = new ReverseBits();
        uint _n;

        private void Read()
        {
            _n = 43261596;
        }

        public void Do()
        {
            Read();
            var val = Reverse2(_n);
        }

        private uint Reverse(uint n)
        {
            uint ret =0;
            int pow = 31;

            while(n!=0)
            {
                ret += (n & 1) << pow;
                n = n >> 1;
                pow -= 1;
            }

            return ret;
        }

        private uint Reverse1(uint n)
        {
            uint ret =0;
            int pow = 24;
            Dictionary<uint, uint> cache = new Dictionary<uint, uint>();
            while(n!=0)
            {
                ret += ReverseByte(n & 0xff, cache) << pow;
                n = n >> 8;
                pow -= 8;
            }

            return ret;
        }

        private uint ReverseByte(uint num, Dictionary<uint, uint> cache)
        {
            if(cache.ContainsKey(num))
                return cache[num];
            
            uint val = (uint)((num * 0x202020202 & 0x10884422010) % 1023);
            cache[num] = val;
            return val;
        }

        private uint Reverse2(uint n)
        {
            n = (n >> 16) | (n << 16);
            n = ((n & 0xff00ff00) >> 8) | ((n & 0x00ff00ff) << 8);
            n = ((n & 0xf0f0f0f0) >> 4) | ((n & 0x0f0f0f0f) << 4);
            n = ((n & 0xcccccccc) >> 2) | ((n & 0x33333333) << 2);
            n = ((n & 0xaaaaaaaa) >> 1) | ((n & 0x55555555) << 1);
            return n;
        }
    }
}