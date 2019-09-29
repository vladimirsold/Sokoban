using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Sokoban;
using Microsoft.Xna.Framework.Media;

namespace Sokoban.View
{
    /// <summary>
    /// Contains all of downloadable content
    /// </summary>
    class LoadedContent
    {
        public readonly Dictionary<TextureID, Texture2D> BlocksTextures;
        public readonly Song BackgroundMusic;
        public readonly SpriteFont Font;
        public readonly Texture2D TextureBackground;

        public LoadedContent(ContentManager content)
        {
            BackgroundMusic = content.Load<Song>("song");
            Font = content.Load<SpriteFont>("Fonts/Font");
            TextureBackground = content.Load<Texture2D>("background");
            BlocksTextures = new Dictionary<TextureID, Texture2D>
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
