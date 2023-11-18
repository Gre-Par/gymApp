using GymApp;

namespace GymApp.Tests
{
    public class Tests
    {
        [Test]
        public void CheckSumOfPoints()
        {
            //arrange
            var participant = new ParticipantInMemory("Scooby", "Doo");
            participant.AddPoint(20);
            participant.AddPoint(11);
            participant.AddPoint(1);
            participant.AddPoint(10);
            participant.AddPoint(17);

            //act
            var statistics = participant.GetStatistics();
            
            //assert
            Assert.AreEqual(59, statistics.Sum);
        }

        [Test]
        public void CheckMaxPoint()
        {
            //arrange
            var participant = new ParticipantInMemory("Scooby", "Doo");
            participant.AddPoint(14);
            participant.AddPoint(15);
            participant.AddPoint(19);
            participant.AddPoint(9);
            participant.AddPoint(10);

            //act
            var statistics = participant.GetStatistics();

            //assert
            Assert.AreEqual(19, statistics.Max);
        }

        [Test]
        public void CheckMinGrade()
        {
            //arrange
            var participant = new ParticipantInMemory("Scooby", "Doo");
            participant.AddPoint(14);
            participant.AddPoint(15);
            participant.AddPoint(12);
            participant.AddPoint(2);
            participant.AddPoint(9);

            //act
            var statistics = participant.GetStatistics();

            //assert
            Assert.AreEqual(2, statistics.Min);
        }

        [Test]
        public void CheckFinalGrade()
        {
            //arrange
            var participant = new ParticipantInMemory("Scooby", "Doo");
            participant.AddPoint(20);
            participant.AddPoint(17);
            participant.AddPoint(19);
            participant.AddPoint(15);
            participant.AddPoint(16);
            //act
            var statistics = participant.GetStatistics();

            //assert
            Assert.AreEqual('5', statistics.FinalGrade);
        }
    }
}