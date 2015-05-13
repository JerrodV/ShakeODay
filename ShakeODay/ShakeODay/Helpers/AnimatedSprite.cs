using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShakeOfTheDay.Helpers
{
    public class AnimatedSprite : Sprite
    {
        public AnimatedSprite() { }
        public Boolean LoopAnimation { get; set; }
        public Boolean KillOnComplete { get; set; }
        public Int32 LoopAnimationCount { get; set; }
        protected Int32 CurrentLoop { get; set; }

        public Rectangle Source { get; set; }
        public Int32 FrameRows { get; set; }
        public Int32 FrameColumns { get; set; }
        public Vector2 DisplaySize { get; set; }

        public Int32 FrameCount
        {
            get
            {
                return FrameColumns * FrameRows;
            }
        }
        private Int32 _CurrentFrame = 0;
        public Int32 CurrentFrame 
        {
            get 
            {
                return _CurrentFrame;
            }
            set 
            {
                _CurrentFrame = value;
            } 
        }
        protected DateTime CreationTime { get; set; }
        protected DateTime LastUpdateTime { get; set; }

        public new Rectangle Rectangle
        {
            get
            {
                return new Rectangle(
                    Convert.ToInt32(this.Position.X),
                    Convert.ToInt32(this.Position.Y),
                    Convert.ToInt32(this.DisplaySize.X),
                    Convert.ToInt32(this.DisplaySize.Y)
                );
            }
        }

        private Int32[,] map 
        {
            get
            {
                Int32[,] retVal = new Int32[FrameRows, FrameColumns];
                int c = 0;
                for (int i = 0; i < FrameRows; i++)
                {
                    for (int j = 0; j < FrameColumns; j++)
                    {
                        retVal[i, j] = c;
                        c++;
                    }
                }
                return retVal;
            }
        }

        public override void LoadContent(ContentManager ContentManager)
        {
            base.LoadContent(ContentManager);
        }
        
        public override void Update(GraphicsDevice device)
        {
            //Move the sprite
            base.Update(device);            
            if(CurrentFrame > (FrameCount - 1))
            {
                if (LoopAnimation)
                {
                    CurrentFrame = 0;
                    if(CurrentLoop > LoopAnimationCount)
                    {
                        this.IsAlive = false;
                    }
                    CurrentLoop++;
                }
                else 
                {
                    if (KillOnComplete)
                    {
                        this.IsAlive = false;
                    }
                }
            }
            
            UpdateSourceRect();
            CurrentFrame++;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.Texture,
                new Vector2
                    (
                        this.Rectangle.X,
                        this.Rectangle.Y
                    ),
                this.Source,
                this.Color,
                this.Rotation,
                this.Origin,
                this.Scale,
                this.SpriteEffect,
                0
            );
        }

        public void UpdateSourceRect()
        {
            for (int i = 0; i < FrameRows; i++)
            {
                for (int j = 0; j < FrameColumns; j++)
                {
                    if (map[i, j] == CurrentFrame)
                    {
                        Source = new Rectangle(
                            Convert.ToInt32((this.Texture.Bounds.Width / FrameColumns) * j),
                            Convert.ToInt32((this.Texture.Bounds.Height / FrameRows) * i),
                            Convert.ToInt32(this.DisplaySize.X),
                            Convert.ToInt32(this.DisplaySize.Y));
                        break;
                    }
                     
                }
            }
        }
    }
}
