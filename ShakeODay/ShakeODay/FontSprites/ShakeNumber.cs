using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using ShakeOfTheDay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShakeOfTheDay.FontSprites
{
    public class ShakeNumber : FontSprite
    {
        public ShakeNumber() { }
        public ShakeNumber(StateManager stateManager)
        {
            this.stateManager = stateManager;
            this.ID = "Georgia";
            this.Text = new StringBuilder("5");
            this.Color = Color.Purple;
            this.Scale = 2.5f;
            this.LoadContent(stateManager.contentManager);
            this.Position = new Vector2(
                        (((stateManager.deviceManager.PreferredBackBufferWidth / 2) - (this.SpriteFont.MeasureString(this.Text).X / 2) * this.Scale)),
                        float.Parse(((stateManager.deviceManager.PreferredBackBufferHeight / 2) - ((this.SpriteFont.MeasureString(this.Text).Y / 2) * this.Scale)).ToString())) ;

        }

        public override void LoadContent(ContentManager ContentManager)
        {
            base.LoadContent(ContentManager);
        }

        public override void Update(Microsoft.Xna.Framework.Graphics.GraphicsDevice device)
        {
            this.Position = new Vector2(
                        (((stateManager.deviceManager.PreferredBackBufferWidth / 2) - (this.SpriteFont.MeasureString(this.Text).X / 2) * this.Scale)),
                        float.Parse(((stateManager.deviceManager.PreferredBackBufferHeight / 2) - ((this.SpriteFont.MeasureString(this.Text).Y / 2) * this.Scale)).ToString()));
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
