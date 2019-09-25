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
        private int blockSize;
        public  Point StartPointDraw { get; private set; }
        private readonly Dictionary<TextureID, Texture2D> textureBlocks;
        private readonly GameModel gameProcess;
        private readonly GraphicsDeviceManager graphics;
        public Field(GameModel gameProcess, Dictionary<TextureID, Texture2D> textureBlocks, GraphicsDeviceManager graphics)
        {
           
            this.textureBlocks = textureBlocks;
            this.gameProcess = gameProcess;
            this.graphics = graphics;
            Update();
        }

        public void Update()
        {
            var defaultBlockSize = Settings.GetSettings().DefaultBlockSize;
            var possibleSizeBlock = new int[]{graphics.PreferredBackBufferWidth / gameProcess.Field.Size.X,
                graphics.PreferredBackBufferHeight / (gameProcess.Field.Size.Y + 1), defaultBlockSize};
            blockSize = possibleSizeBlock.Min();
            var pointX = (graphics.PreferredBackBufferWidth - gameProcess.Field.Size.X * blockSize) / 2;
            var pointY = (graphics.PreferredBackBufferHeight - gameProcess.Field.Size.Y * blockSize) / 2;
            StartPointDraw = new Point(pointX, pointY);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach(var gameObject in GetGameObjectsForDraw(gameProcess.Field))
            {

                spriteBatch.Draw(gameObject.Texture, gameObject.Rectangle, Color.White);
            }
            spriteBatch.End();
        }

        private IEnumerable<DrawableGameObject> GetGameObjectsForDraw(Sokoban.Model.Field field)
        {
            var rows = field.Storeroom.GetUpperBound(0) + 1;
            var columns = field.Storeroom.GetUpperBound(1) + 1;
            for(int i = 0; i <rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    if(field.Storeroom[i,j] != null)
                    {
                        var texture = GetTextureMatchingGameObject(field.Storeroom[i, j]);
                        var rectangle = GetRectangleMatchingCoords(i, j);
                        yield return new DrawableGameObject(texture, rectangle);
                    }
                }
            }
            foreach(var cell in field.CellForBoxes)
            {
                var texture = GetTextureMatchingGameObject(cell);
                var rectangle = GetRectangleMatchingCoords(cell.X, cell.Y);
                yield return new DrawableGameObject(texture, rectangle);
            }

            yield return new DrawableGameObject(
                GetTextureMatchingGameObject(field.Storekeeper), 
                GetRectangleMatchingCoords(field.Storekeeper.Coordinates.X, field.Storekeeper.Coordinates.Y));
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
  
        Rectangle GetRectangleMatchingCoords(int x, int y)
        {
            return new Rectangle(x * blockSize + StartPointDraw.X, y * blockSize + StartPointDraw.Y, blockSize, blockSize);
        }
    }
}
