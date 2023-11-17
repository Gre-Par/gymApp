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
            fileNameSurname = $"{name}_{surname}{fileName}";
        }
           
        public override void AddPoint(int point)
        {
            if (point >= 0 && point <= 20)
            {
                using (var writer = File.AppendText($"{fileNameSurname}"))
                //using (var writer2 = File.AppendText($"audit.txt"))
                {
                    writer.WriteLine(point);
                    //writer2.WriteLine($"{Name} {Surname} - {point}        {DateTime.UtcNow}");
                }
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




//    internal class Program
//    {
//        private static void Main(string[] args)
//        {
//            WritelineColor(ConsoleColor.Magenta, "Hello to the [Student's Grades Book] console app.");

//            bool CloseApp = false;

//            while (!CloseApp)
//            {
//                Console.WriteLine();
//                WritelineColor(ConsoleColor.Cyan,
//                    "1 - Add student's grades to the program memory and show statistics\n" +
//                    "2 - Add student's grades to the .txt file and show statistics\n" +
//                    "X - Close app\n");

//                WritelineColor(ConsoleColor.Yellow, "What you want to do? \nPress key 1, 2 or X: ");
//                var userInput = Console.ReadLine().ToUpper();

//                switch (userInput)
//                {
//                    case "1":
//                        AddGradesToMemory();
//                        break;

//                    case "2":
//                        AddGradesToTxtFile();
//                        break;

//                    case "X":
//                        CloseApp = true;
//                        break;

//                    default:
//                        WritelineColor(ConsoleColor.Red, "Invalid operation.\n");
//                        continue;
//                }
//            }
//            WritelineColor(ConsoleColor.DarkYellow, "\n\nBye Bye! Press any key to leave.");
//            Console.ReadKey();
//        }

//        static void OnGradeUnder3(object sender, EventArgs args)
//        {
//            WritelineColor(ConsoleColor.DarkYellow, $"Oh no! Student got grade under 3. We should inform student’s parents about this fact!");
//        }

//        private static void AddGradesToTxtFile()
//        {
//            string firstName = GetValueFromUser("Please insert student's first name: ");
//            string lastName = GetValueFromUser("Please insert student's last name: ");
//            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
//            {
//                var savedStudent = new StudentSaved(firstName, lastName);
//                savedStudent.GradeUnder3 += OnGradeUnder3;
//                EnterGrade(savedStudent);
//                savedStudent.ShowStatistics();
//            }
//            else
//            {
//                WritelineColor(ConsoleColor.Red, "Student's firstname and lastname can not be empty!");
//            }
//        }

//        private static void EnterGrade(IStudent student)
//        {
//            while (true)
//            {
//                WritelineColor(ConsoleColor.Yellow, $"Enter grade for {student.FirstName} {student.LastName}:");
//                var input = Console.ReadLine();

//                if (input == "q" || input == "Q")
//                {
//                    break;
//                }
//                try
//                {
//                    student.AddGrade(input);
//                }
//                catch (FormatException ex)
//                {
//                    WritelineColor(ConsoleColor.Red, ex.Message);
//                }
//                catch (ArgumentException ex)
//                {
//                    WritelineColor(ConsoleColor.Red, ex.Message);
//                }
//                catch (NullReferenceException ex)
//                {
//                    WritelineColor(ConsoleColor.Red, ex.Message);
//                }
//                finally
//                {
//                    WritelineColor(ConsoleColor.DarkMagenta, $"To leave and show {student.FirstName} {student.LastName} statistics enter 'q'.");
//                }
//            }
//        }

//        private static void WritelineColor(ConsoleColor color, string text)
//        {
//            Console.ForegroundColor = color;
//            Console.WriteLine(text);
//            Console.ResetColor();
//        }

//        private static string GetValueFromUser(string comment)
//        {
//            WritelineColor(ConsoleColor.Yellow, comment);
//            string userInput = Console.ReadLine();
//            return userInput;
//        }
//    }
//}