using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    [TestFixture]
    public class GameModel_Test
    {
        GameModel game = new GameModel();
        [Test]
        public void TestCollision()
        {
            game.LoadLevel(new Level(Series.Test,1));
            var startPosition = new int[] { game.Storekeeper.X, game.Storekeeper.Y };
            game.Move(Direction.Right);
            var newPosition = new int[] { game.Storekeeper.X, game.Storekeeper.Y };
            Assert.AreEqual(startPosition, newPosition);
        }
    }
}
