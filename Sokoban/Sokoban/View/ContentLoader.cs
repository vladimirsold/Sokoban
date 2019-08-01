using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.View
{ 
    class ContentLoader
    {
        public Dictionary<TextureID, Texture2D> TextureBlocks { get; private set; }
        public SpriteFont Font { get; private set; }

        public ContentLoader(ContentManager content)
        {
            Font = content.Load<SpriteFont>("Fonts/Font");
            TextureBlocks = new Dictionary<TextureID, Texture2D>
            {
                [TextureID.Wall] = content.Load<Texture2D>("Blocks/block_05"),
                [TextureID.PlayerTurnedForward] = content.Load<Texture2D>("Player/Forward"),
                [TextureID.PlayerTurnedBackward] = content.Load<Texture2D>("player/Backward"),
                [TextureID.PlayerTurnedLeft] = content.Load<Texture2D>("Player/Left"),
                [TextureID.PlayerTurnedRight] = content.Load<Texture2D>("Player/Right"),
                [TextureID.Box] = content.Load<Texture2D>("Crates/crate_09"),
                [TextureID.EmptyCell] = content.Load<Texture2D>("Crates/crate_29"),
                [TextureID.CellWithBox] = content.Load<Texture2D>("Crates/crate_44")
            };
        }
    }
}
