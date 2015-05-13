using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using ShakeOfTheDay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShakeOfTheDay.FontSprites
{
    public class TodaysNumberString : FontSprite
    {
        public TodaysNumberString(StateManager stateManager) 
        {
            this.stateManager = stateManager;
            this.ID = "Georgia";
            this.Text = new StringBuilder("Today's Number");
            this.Color = Color.Blue;
            Scale = .01f;
            this.LoadContent(stateManager.contentManager);
            //We have to do this after the LoadContent or the SpiteFont is not availible.
            this.Position = new Vector2(
                        (((stateManager.deviceManager.PreferredBackBufferWidth / 2) - (this.SpriteFont.MeasureString(this.Text).X / 2) * Scale)),
                        float.Parse((stateManager.deviceManager.PreferredBackBufferHeight / .5).ToString()));
            
        }

        public override void LoadContent(ContentManager ContentManager)
        {
            base.LoadContent(ContentManager);
        }

        public override void Update(Microsoft.Xna.Framework.Graphics.GraphicsDevice device)
        {
            this.Position = new Vector2(
                        (((stateManager.deviceManager.PreferredBackBufferWidth / 2) - (this.SpriteFont.MeasureString(this.Text).X / 2) * Scale)),
                        float.Parse((stateManager.deviceManager.PreferredBackBufferHeight / 1.3).ToString()));
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
