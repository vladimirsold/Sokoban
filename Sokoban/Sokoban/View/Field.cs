using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Sokoban;
using Sokoban.Model;

namespace View
{
    class Field
    {
        private readonly int blockSize;
        private readonly Point pointDraw;
        private readonly Dictionary<TextureID, Texture2D> textureBlocks;
        private GameModel gameProcess;
        public Field(GameModel gameProcess, Dictionary<TextureID, Texture2D> textureBlocks, GraphicsDeviceManager graphics, int defaultBlockSize)
        {
            this.textureBlocks = textureBlocks;
            this.gameProcess = gameProcess;
            var possibleSizeBlock = new int[]{graphics.PreferredBackBufferWidth / gameProcess.FieldSize.X,
                graphics.PreferredBackBufferHeight / (gameProcess.FieldSize.Y + 1), defaultBlockSize};
            blockSize = possibleSizeBlock.Min();           
            var pointX = (graphics.PreferredBackBufferWidth - gameProcess.FieldSize.X * blockSize) / 2;
            var pointY = (graphics.PreferredBackBufferHeight - gameProcess.FieldSize.Y * blockSize) / 2;
            pointDraw = new Point(pointX, pointY);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach(var gameObject in gameProcess.GetAllGameObjects())
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
            return new Rectangle(gameObject.X * blockSize + pointDraw.X, gameObject.Y * blockSize + pointDraw.Y, blockSize, blockSize);
        }
    }
}
