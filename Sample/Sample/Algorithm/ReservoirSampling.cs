using System;
using Sample.LS;

namespace Sample.Algorithm
{
    public class ReservoirSampling
    {
        public static ReservoirSampling Instance = new ReservoirSampling();

        Random r = new Random();

        public int[] Random(Node root, int k)
        {
            Node curr = root;
            int i=0;
            int[] reservoir = new int[k];
            // Initialzing the output array to the first k
            // elements of the input array
            while(root != null && i<k)
            {
                reservoir[i] = curr.Value;
                curr = curr.Next;
                i++;
            }
        
            // Iterating from k to n-1
            while(curr != null)
            {
                // Generating a randon number from 0 to j
                int randomIndex = r.Next(++i);
                // Replacing an element in the output with an element
                // in the input if the randomly generated number is less
                // than k.
                if(randomIndex <= k)
                    reservoir[randomIndex] = curr.Value;
                
                curr = curr.Next;
            }

            return reservoir;
        }
    }
}