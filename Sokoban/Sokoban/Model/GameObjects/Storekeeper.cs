using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban.Model
{
    class Storekeeper : GameObject
    {
        public Vector Coordinates { get; private set; }
        public Direction State { get; private set; }
        readonly GameObject[,] storeroom;
        public Storekeeper(Vector coordinates, GameObject[,] storeroom)
        {
            Coordinates = coordinates;
            State = Direction.Down;
            this.storeroom = storeroom;
        }

        public void TryMove(Direction direction)
        {
            var coordsToMove = new Vector(Coordinates, direction);
            State = direction;
            if(IsWallCollision(coordsToMove))
            {
                return;
            }
            if(IsBoxCollision(coordsToMove))
            {
                if(!TryMoveBox(coordsToMove, direction))
                {
                    return;
                }
            }
            Coordinates = coordsToMove;
  
        }

        private bool TryMoveBox(Vector coordsOfBox, Direction direction)
        { 
            var coordsToMoveBox = new Vector(coordsOfBox, direction);
            if(storeroom[coordsToMoveBox.X, coordsToMoveBox.Y] == null)
            {
                MoveBox(coordsOfBox,coordsToMoveBox);
                return true;
            }
            return false;
        }

        private void MoveBox(Vector coordsOfBox, Vector coordsToMoveBox)
        {
            storeroom[coordsToMoveBox.X, coordsToMoveBox.Y] = storeroom[coordsOfBox.X, coordsOfBox.Y];
            storeroom[coordsOfBox.X, coordsOfBox.Y] = null;
        }

        private bool IsBoxCollision(Vector coordsToMove)
        {
            return storeroom[coordsToMove.X, coordsToMove.Y] is Box;
        }

        private bool IsWallCollision(Vector coordsToMove)
        {
            return storeroom[coordsToMove.X, coordsToMove.Y] is Wall;
        }
    }
}
