using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShakeOfTheDay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShakeOfTheDay.Sprites
{
    public class BgGrad : Sprite
    {
        StateManager stateManager;
        public BgGrad(StateManager stateManager) 
        {
            this.stateManager = stateManager;
            this.ID = "radiusFill";            
            this.Opacity = .2f;
            this.Color = Color.White;
            this.LoadContent(stateManager.contentManager);
            this.Size = new Vector2(
                    stateManager.deviceManager.PreferredBackBufferWidth,
                    stateManager.deviceManager.PreferredBackBufferHeight
                );
        }

        public override void Update(GraphicsDevice device) 
        {
            //Move the sprite
            base.Update(device);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {   
            //spriteBatch.Draw(this.Texture, new Vector2(this.Rectangle.X, this.Rectangle.Y), null, this.Color, this.Rotation, this.Origin, this.Scale, this.SpriteEffect, 0);                        
            spriteBatch.Draw(this.Texture, new Rectangle(0, 0, stateManager.deviceManager.PreferredBackBufferWidth, stateManager.deviceManager.PreferredBackBufferHeight), this.Color);
        }
    }
}
