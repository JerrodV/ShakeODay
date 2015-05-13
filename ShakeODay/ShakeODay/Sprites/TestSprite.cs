using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShakeOfTheDay.Helpers;


namespace ShakeOfTheDay.Sprites
{
    public class TestSprite : Sprite
    {
        public TestSprite(ContentManager contentManager) 
        { 
            this.ID = "Alien1";
            this.Scale = 1;
            this.speedX = 2;
            this.LoadContent(contentManager);
        }

        public override void Update(GraphicsDevice device) 
        {
            //Move the sprite
            base.Update(device);

            //Check for collisions
            Rectangle screenRect = device.PresentationParameters.Bounds;
            if (this.Rectangle.Right > screenRect.Right
                || this.Rectangle.Left < screenRect.Left
                )
            {
                this.speedX = this.speedX * -1;
                if (this.SpriteEffect == SpriteEffects.FlipHorizontally)
                {
                    this.SpriteEffect = SpriteEffects.None;
                }
                else
                {
                    this.SpriteEffect = SpriteEffects.FlipHorizontally;
                }
            }

            if (this.Rectangle.Top > screenRect.Top
                || this.Rectangle.Bottom < screenRect.Bottom
                )
            {
                this.speedY = this.speedY * -1;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, new Vector2(this.Rectangle.X, this.Rectangle.Y), null, this.Color, this.Rotation, this.Origin, this.Scale, this.SpriteEffect, 0);            
        }
    }
}
