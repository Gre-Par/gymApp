using static GymApp.ParticipantBase;

namespace GymApp
{
    internal interface IParticipant
    {
        string Name { get; }
      
        string Surname { get; }
        
        void AddPoint(int point);
        
        void AddPoint(char point);
        
        void AddPoint(string point);

        event PointAddedDelegate PointAdded;
        
        Statistics GetStatistics();
    }
}