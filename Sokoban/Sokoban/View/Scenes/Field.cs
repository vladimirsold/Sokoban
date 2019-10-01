using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sokoban.View.Scenes
{
    class Field
    {
        private int blockSize;
        public Point StartPointDraw { get; private set; }
        private readonly Dictionary<TextureID, Texture2D> textureBlocks;
        private readonly IEnumerable<GameObject> gameObjects;

        private Point sizeOfStoreroom;

        public Field(IEnumerable<GameObject> gameObjects, Point sizeOfStoreroom, Dictionary<TextureID, Texture2D> textureBlocks)
        {

            this.textureBlocks = textureBlocks;
            this.gameObjects = gameObjects;
            this.sizeOfStoreroom = sizeOfStoreroom;
        }

        public void Init(Point startPointDraw, Point sizeOfField)
        {
            var defaultBlockSize = Settings.GetSettings().DefaultBlockSize;
            var possibleSizeBlock = new int[]{sizeOfField.X / sizeOfStoreroom.X,
                sizeOfField.Y / (sizeOfStoreroom.Y + 1), defaultBlockSize};
            blockSize = possibleSizeBlock.Min();
            var x = (sizeOfField.X - sizeOfStoreroom.X * blockSize) / 2 + startPointDraw.X;
            var y = (sizeOfField.Y - sizeOfStoreroom.Y * blockSize) / 2 + startPointDraw.Y;
            StartPointDraw = new Point(x, y);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach(var gameObject in gameObjects)
            {
                var rectangle = GetRectangleMatchingGameObject(gameObject);
                var texture = GetTextureMatchingGameObject(gameObject);
                spriteBatch.Draw(texture, rectangle, Color.White);
            }
            spriteBatch.End();
        }

        private Texture2D GetTextureMatchingGameObject(GameObject gameObject)
        {
            if(gameObject is Storekeeper player)
            {
                switch(player.State)
                {
                    case Direction.Up:
                        return textureBlocks[TextureID.PlayerTurnedBackward];
                    case Direction.Down:
                        return textureBlocks[TextureID.PlayerTurnedForward];
                    case Direction.Left:
                        return textureBlocks[TextureID.PlayerTurnedLeft];
                    case Direction.Right:
                        return textureBlocks[TextureID.PlayerTurnedRight];
                }
            }
            if(gameObject is Wall)
            {
                return textureBlocks[TextureID.Wall];
            }
            if(gameObject is Box)
            {
                return textureBlocks[TextureID.Box];
            }
            if(gameObject is CellForBox cellForBox)
            {
                return cellForBox.IsEmpty ? textureBlocks[TextureID.EmptyCell] : textureBlocks[TextureID.CellWithBox];
            }
            throw new ArgumentException();
        }

        Rectangle GetRectangleMatchingGameObject(GameObject gameObject)
        {
            return new Rectangle(gameObject.Coordinates.X * blockSize + StartPointDraw.X, gameObject.Coordinates.Y * blockSize + StartPointDraw.Y, blockSize, blockSize);
        }
    }
}