using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoreGames.Domain.Entities.Dices;
using ScoreGames.Domain.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ScoreGames.Domain.Tests
{
    [TestClass]
    public class AuroraScoreUnitTest
    {
        private readonly int AuroraValue = 50; 
        private List<Dice[]> AuroraPlays { get; set; }

        public AuroraScoreUnitTest()
        {
            AuroraPlays = new List<Dice[]>();
            for (int i = 0; i < 6; i++)
            {
                AuroraPlays.Add(new Dice[5]);
                var dice = DiceFactory.CreateDice(i+1);
                for (int j = 0; j < 5; j++)
                    AuroraPlays[i][j] = dice;
            }
        }

        [TestMethod]
        public void Test_Aurora_Score_Factory()
        {
            for (int i = 1; i < 7; i++)
            {
                var dice = DiceFactory.CreateDice(i);
                Assert.IsNotNull(dice, "DiceFactory must create a valid Dice for values between 1 and 6");
                Assert.IsTrue(dice.Value == i, "The created Dice must contains same value as the CreateDice parameter value.");
            }
        }

        [TestMethod]
        public void Test_Aurora_Move_Through_AuroraAssistentService()
        {
            var assistant = new AuroraAssistantService(new Entities.Aurora.ScoreAuroraFactory());
            foreach (var move in AuroraPlays)
            {
                var result = assistant.GetPossibleScoresByMove(move);
                Assert.IsNotNull(result, "Tests if the assistant returns a list of scores");
                result = result.ToList();
                Assert.IsTrue(result.Any(s=>s.Value == AuroraValue),"Tests if the result contains at least one Aurora Score");
                var score = result.First(s => s.Value == AuroraValue);
                Assert.IsTrue(score.Move.Count() == 5, "Aurora move must have 5 dices");
                var dice = score.Move.First();
                Assert.IsTrue(score.Move.All(d => d.Value == dice.Value), "Aurora move must have all 5 dices equal");
            }
        }
    }
}
