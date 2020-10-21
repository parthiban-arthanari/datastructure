using System;

namespace Sample.BackTracking
{
    public class RobotTrajectory
    {
        public static RobotTrajectory Instance = new RobotTrajectory();

        string _path;

        private void Read()
        {
            _path = "GGGLGLGLGG";
        }

        public void Do()
        {
            Read();
            var val = IsBounded(_path);
        }

        private bool IsBounded(string path)
        {
            int[,] directions = new int[,]{{0,1}, {1,0}, {0,-1}, {-1,0}};
            int x = 0, y = 0, idx =0;

            for(int i=0; i<path.Length; i++)
            {
                switch(path[i])
                {
                    case 'R':
                        idx = (idx +1) %4;
                        break;
                    case 'L':
                        idx = (idx +3) %4;
                        break;
                    case 'G':
                        x+=directions[idx,0];
                        y+=directions[idx,1];
                        break;
                }
            }

            return (x==0 && y==0) || (idx !=0);
        }
    }
}