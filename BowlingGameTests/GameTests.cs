using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGameKata;

namespace BowlingGameTests
{
    [TestClass]
    public class GameTests
    {
        private Game game_;

        [TestInitialize]
        public void Initialize()
        {
            game_ = new Game();
        }
        private void RollMany(int numberOfRolls, int pinsOnEachRoll)
        {
            for (int i = 0; i < numberOfRolls; i++)
                game_.Roll(pinsOnEachRoll);
        }

        [TestMethod]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, game_.Score());
        }
        [TestMethod]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, game_.Score());
        }
        [TestMethod]
        public void TestOneSpare()
        {
            RollSpare();
            game_.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, game_.Score());
        }
        [TestMethod]
        public void TestOneStrike()
        {
            RollStrike();
            game_.Roll(3);
            game_.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, game_.Score());
        }
        [TestMethod]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, game_.Score());
        }
        private void RollStrike()
        {
            game_.Roll(10);
        }
        private void RollSpare()
        {
            game_.Roll(5);
            game_.Roll(5);
        }
    }
}
