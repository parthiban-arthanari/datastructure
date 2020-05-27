using System;

namespace Sample
{
    public class FindStraightLine
    {
        public static FindStraightLine Instance = new FindStraightLine();

        int[][] coordinates;

        public void Do()
        {
            Read();
            Console.WriteLine("Give line is Straight Line : {0}", IsStraightLine(coordinates));
        }

        private bool IsStraightLine(int[][] coordinates)
        {
            double xdiff = -1;
            double ydiff = -1;
            for(int i=1; i<coordinates.Length; i++)
            {
                double x1 = Math.Abs(coordinates[i][0] - coordinates[i-1][0]);
                double y1 = Math.Abs(coordinates[i][1] - coordinates[i-1][1]);

                if( xdiff >= 0)
                {
                    if(xdiff < x1)
                    {
                        double temp = x1;
                        x1 = xdiff;
                        xdiff = temp;

                        temp = y1;
                        y1= ydiff;
                        ydiff = temp;
                    }

                    if((xdiff == 0 && x1 > 0) || (ydiff == 0 && y1 > 0))
                        return false;
                    
                    if(xdiff > 0 && ydiff > 0)
                    {
                        double m = ydiff / xdiff;
                        double m1 = y1/x1;

                        if(m != m1)
                            return false;
                    } 
                }
                else
                {
                    xdiff = x1;
                    ydiff = y1;
                }
            }

            return true;
        }

        private void Read()
        {
            coordinates = new int[5][];
            coordinates[0] = new int[] { -4,-3};
            coordinates[1] = new int[] { 1,0};
            coordinates[2] = new int[] { 3,-1};
            coordinates[3] = new int[] { 0,-1};
            coordinates[4] = new int[] { -5,2};
            // coordinates[5] = new int[] { 7,7};
        }
    }
}