using System;

namespace Sample.Array
{
    public class AngleBwClock
    {
        public static AngleBwClock Instance = new AngleBwClock();

        int x1,x2;

        private void Read()
        {
            x1= 6;
            x2 = 5;
        }

        public void Do()
        {
            Read();
            var val = Angle(x1, x2);
        }

        private double Angle(int hour, int minutes)
        {
            int oneMinAngle = 6;
            int oneHourAngle = 30;

            double minutesAngle = oneMinAngle * minutes;
            double hourAngle = (hour % 12 + minutes / 60.0) * oneHourAngle;

            double diff = Math.Abs(hourAngle - minutesAngle);
            return Math.Min(diff, 360 - diff);
        }
    }
}