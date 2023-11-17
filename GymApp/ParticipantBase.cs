using GymApp;

namespace GymApp
{
    public abstract class ParticipantBase : IParticipant
    {
        public delegate void PointAddedDelegate(object sender, EventArgs args);
        public abstract event PointAddedDelegate PointAdded;
        public ParticipantBase(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public string Name { get; private set; }

        public string Surname { get; private set; }

        public abstract void AddPoint(int point);

        public void AddPoint(char point)
        {
            switch (point)
            {
                case 'A':
                case 'a':
                    AddPoint(20);
                    break;
                case 'B':
                case 'b':
                    AddPoint(15);
                    break;
                case 'C':
                case 'c':
                    AddPoint(10);
                    break;
                case 'D':
                case 'd':
                    AddPoint(5);
                    break;
                case 'E':
                case 'e':
                    AddPoint(0);
                    break;
                default:
                    throw new Exception("Wrong letter");
            }
        }

        public void AddPoint(string point)
        {
            if (int.TryParse(point, out int result))
            {
                AddPoint(result);
            }
            else
            {
                throw new Exception("Ups, nie udało się. Przejdź do kolejnego wyzwania. Powodzenia!");
            }
        }

        public abstract Statistics GetStatistics();
    }
}