namespace GymApp.Tests
{
    public class Tests
    {
        [Test]
        public void CheckIfStatisticsAreCorrectSumMaxMinFinalGrade()
        {
            //arrange
            var participant = new ParticipantInMemory("Scooby", "Doo");
            participant.AddPoint(20);
            participant.AddPoint(11);
            participant.AddPoint(1);
            participant.AddPoint(9);
            participant.AddPoint(17);

            //act
            var statistics = participant.GetStatistics();
            
            //assert
            Assert.AreEqual(58, statistics.Sum);
            Assert.AreEqual(20, statistics.Max);
            Assert.AreEqual(1, statistics.Min);
            Assert.AreEqual('3', statistics.FinalGrade);
        }
    }
}