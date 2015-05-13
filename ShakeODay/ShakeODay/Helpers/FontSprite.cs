using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShakeOfTheDay.Helpers
{
    public class FontSprite : Sprite
    {   
        
        public StringBuilder Text { get; set; }
        public SpriteFont SpriteFont { get; set; }
        public StateManager stateManager { get; set; }
        
        public FontSprite() { }
        public FontSprite(StateManager stateManager) 
        {
            this.stateManager = stateManager;
        }
        
        public override void LoadContent(ContentManager ContentManager)
        {
            this.SpriteFont = ContentManager.Load<SpriteFont>(this.ID);
        }

        public override void Update(GraphicsDevice device)
        {
            base.Update(device);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                this.SpriteFont,
                this.Text,
                this.Position,
                this.Color,
                this.Rotation,
                this.Origin,
                this.Scale,
                SpriteEffects.None,
                1
            );
        }
    }
}
