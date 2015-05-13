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
    public class SnuffysString : FontSprite
    {
        public SnuffysString(StateManager stateManager) 
        {
            this.stateManager = stateManager;
            this.ID = "Georgia";
            this.Text = new StringBuilder("Snuffy's");
            this.Scale = 1.2f;
            this.Color = Color.Blue;
            this.LoadContent(stateManager.contentManager);
            //We have to do this after the LoadContent or the SpiteFont is not availible.
            this.Position = new Vector2(
                        (stateManager.deviceManager.PreferredBackBufferWidth / 2) - ((this.SpriteFont.MeasureString(this.Text).X / 2) * Scale),
                        (stateManager.deviceManager.PreferredBackBufferHeight * .01f));
            
        }

        public override void LoadContent(ContentManager ContentManager)
        {
            base.LoadContent(ContentManager);
        }

        public override void Update(GraphicsDevice device)
        {
            base.Update(device);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
