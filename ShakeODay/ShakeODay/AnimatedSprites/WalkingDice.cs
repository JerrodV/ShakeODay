using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShakeOfTheDay.Helpers;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace ShakeOfTheDay.AnimatedSprites
{
    public class WalkingDice : AnimatedSprite
    {        
        StateManager stateManager;
        public WalkingDice(StateManager stateManager) 
        {
            this.stateManager = stateManager;
            this.CreationTime = DateTime.Now;
            this.ID = "WalkingDiceTile";
            this.FrameColumns = 2;
            this.FrameRows = 3;
            this.LoopAnimation = true;
            this.LoopAnimationCount = 10;
            this.DisplaySize = new Vector2(715, 500);
            this.Scale = 1f;
            this.Position = new Vector2
                (
                    (stateManager.deviceManager.PreferredBackBufferWidth / 2) - (this.DisplaySize.X / 2),
                    (stateManager.deviceManager.PreferredBackBufferHeight / 2) - (this.DisplaySize.Y / 2)
                );
            this.LoadContent(stateManager.contentManager);
            this.UpdateSourceRect();

        }

        public override void LoadContent(ContentManager ContentManager)
        {
            base.LoadContent(ContentManager);
        }

        public override void Update(GraphicsDevice device)
        {            
            TimeSpan ts = DateTime.Now - LastUpdateTime;
            if (ts.TotalMilliseconds > 100)
            {
                LastUpdateTime = DateTime.Now;
                base.Update(device);
            }

            if (!this.IsAlive)
            {
                stateManager.State = States.DisplayNumber;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);           
        }
    }
}
