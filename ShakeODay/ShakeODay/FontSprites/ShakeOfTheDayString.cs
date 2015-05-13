using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShakeOfTheDay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShakeOfTheDay.FontSprites
{
    public class ShakeOfTheDayString : FontSprite
    {
        
        public ShakeOfTheDayString() { }
        public ShakeOfTheDayString(StateManager stateManager)
        {
            this.stateManager = stateManager;
            this.ID = "Georgia";
            this.Text = new StringBuilder("Shake of the Day");
            this.Color = Color.Red;
            this.Scale = .7f;
            this.LoadContent(stateManager.contentManager);
            this.Position = new Vector2(
                        (((stateManager.deviceManager.PreferredBackBufferWidth / 2) - (this.SpriteFont.MeasureString(this.Text).X / 2) * Scale)),
                        float.Parse((stateManager.deviceManager.PreferredBackBufferHeight / 1.5).ToString()));

        }

        public override void LoadContent(ContentManager ContentManager)
        {
            base.LoadContent(ContentManager);
        }

        public override void Update(GraphicsDevice device)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
