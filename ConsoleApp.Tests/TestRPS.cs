using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App05;
namespace ConsoleApp.Tests
{
    [TestClass]
    public class TestRPS
    {
        private Game game = new Game("Phill");

        [TestMethod]
        public void TestGameStart()
        {
            game.Start();

            Assert.AreEqual(0, game.Human.Score);
            Assert.AreEqual(0, game.CPU.Score);
            Assert.AreEqual(1, game.Round);

            Assert.AreEqual(GamePlayers.Human, game.CurrentPlayer.PlayerType);

            Assert.AreEqual("Phill", game.Human.Name);
            Assert.AreEqual("CPU", game.CPU.Name);
        }
        [TestMethod]
        public void TestCPUChoiceIsRandom()
        {
            int[] choices = new int[4];

            game.Start();

            for (int i = 0; i < 10000; i++)
            {
                game.MakeCPUChoice();
                int choiceNo = (int)game.CPU.Choice;
                choices[choiceNo]++;
            }

            Assert.IsTrue(choices[0] == 0);
            Assert.IsTrue(choices[1] > 3000);
            Assert.IsTrue(choices[2] > 3000);
            Assert.IsTrue(choices[3] > 3000);
        }

        [TestMethod]
        public void TestScoreForRockAndPaper()
        {
            game.Start();

            game.Human.Choice = GameChoice.Rock;
            game.CPU.Choice = GameChoice.Paper;

            game.ScoreRound();

            Assert.AreEqual(0, game.Human.Score);
            Assert.AreEqual(2, game.CPU.Score);
            Assert.AreEqual(game.Winner.PlayerType, GamePlayers.CPU);
        }

        [TestMethod]
        public void TestScoreForRockAndScissors()
        {
            game.Start();

            game.Human.Choice = GameChoice.Rock;
            game.CPU.Choice = GameChoice.Scissors;

            game.ScoreRound();

            Assert.AreEqual(2, game.Human.Score);
            Assert.AreEqual(0, game.CPU.Score);
            Assert.AreEqual(game.Winner.PlayerType, GamePlayers.Human);
        }

        [TestMethod]
        public void TestScoreForRockAndRock()
        {
            game.Start();

            game.Human.Choice = GameChoice.Rock;
            game.CPU.Choice = GameChoice.Rock;

            game.ScoreRound();

            Assert.AreEqual(1, game.Human.Score);
            Assert.AreEqual(1, game.CPU.Score);
            Assert.AreEqual(game.Winner.PlayerType, GamePlayers.None);
        }
    }
}