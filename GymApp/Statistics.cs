using GymApp;

namespace GymApp
{
    public class Statistics
    {
        public int Sum { get; private set; }

        public int Min { get; private set; }

        public int Max { get; private set; }

        public int Count { get; private set; }

        public char FinalGrade
        {
            get
            {
                switch (Sum)
                {
                    case var sum when sum >= 80:
                        return '5';
                    case var sum when sum >= 60:
                        return '4';
                    case var sum when sum >= 40:
                        return '3';
                    case var sum when sum >= 20:
                        return '2';
                    default:
                        return '1';
                }
            }
        }

        public Statistics()
        {
            Sum = 0;
            Max = int.MinValue;
            Min = int.MaxValue;
            Count = 0;
        }

        public void AddPoint(int point)
        {
            Sum += point;
            Count++;
            Min = Math.Min(point, this.Min);
            Max = Math.Max(point, this.Max);
        }
    }
}