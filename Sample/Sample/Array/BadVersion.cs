using System;
namespace Sample.Array
{
    public class BadVersion
    {
        private int badVersion;
        private int currentVersion;
        public static BadVersion Instance = new BadVersion();

        private void Read()
        {
            currentVersion = 19;
            badVersion = 19;
        }

        public void Do()
        {
            Read();
            Console.WriteLine("Bad Version : {0}", FindBadVersion(currentVersion));
        }

        private int FindBadVersion(int n)
        {
            return FindBadVersion(1, n);
        }

        private int FindBadVersion(int start, int end)
        {
            int length = end - start + 1;
            if(length > 1)
            {
                int mid = start + length/2 -1;
                if (isBadVersion(mid))
                    return FindBadVersion(start, mid);
                return FindBadVersion(mid+1, end);
            }
            return start;
        }

        private bool isBadVersion(int n)
        {
            return n >= badVersion;
        }
    }
}
