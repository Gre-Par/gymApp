namespace GymApp
{
    internal class ParticipantInMemory : ParticipantBase

    {
        public override event PointAddedDelegate PointAdded;

        private List<float> points = new List<float>();
        public ParticipantInMemory(string name, string surname)
            : base(name, surname)
        {
        }
        public override void AddPoint(int point)
        {
            if (point >= 0 && point <= 20)
            {
                points.Add(point);
                if (PointAdded != null)
                {
                    PointAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Wrong number entered");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            foreach (int point in points)
            {
                statistics.AddPoint(point);
            }
            return statistics;
        }
    }
}
