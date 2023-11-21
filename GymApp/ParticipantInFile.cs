namespace GymApp
{
    public class ParticipantInFile : ParticipantBase
    {
        public override event PointAddedDelegate PointAdded;

        private const string fileName = "points.txt";

        private string fileNameSurname;

        public ParticipantInFile(string name, string surname)
            : base(name, surname)
        {
            fileNameSurname = $"{name}_{surname}_{fileName}";
        }

        public override void AddPoint(int point)
        {
            if (point > 0 && point <= 20)
            {
                using (var writer = File.AppendText($"{fileNameSurname}"))
                {
                    writer.WriteLine(point);
                }
                if (PointAdded != null)
                {
                    PointAdded(this, new EventArgs());
                }
            }
            else if (point == 0)
            {
                Console.WriteLine("Nie udało się. Przejdź do kolejnego wyzwania. Powodzenia!");
            }
            else
            {
                throw new Exception("Wrong number entered");
            }
        }

        public override Statistics GetStatistics()
        {
            var pointsFromFile = ReadPointsFromFile();
            var result = CountStatistics(pointsFromFile);
            return result;
        }

        private List<float> ReadPointsFromFile()
        {
            var points = new List<float>();
            if (File.Exists($"{fileNameSurname}"))
            {
                using (var reader = File.OpenText($"{fileNameSurname}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        points.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return points;
        }

        private Statistics CountStatistics(List<float> points)
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