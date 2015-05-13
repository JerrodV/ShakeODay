using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ShakeOfTheDay.Helpers
{
    public class Sprite
    {
        public Sprite() { }
        public String ID { get; set; }
        public Texture2D Texture { get; set; }
        
        private Color _Color = Color.White;
        public Color Color 
        {
            get
            {
                return _Color * this.Opacity;
            }
            set 
            {
                _Color = value;
            } 
        }
        
        private Vector2 _Size = Vector2.Zero;
        public Vector2 Size 
        {
            get 
            {
                return this._Size;
            }
            set
            {
                this._Size = value;
            }
        }

        private float _Scale = 1;
        public float Scale
        {
            get 
            {
                return _Scale;
            }
            set
            {
                _Scale = value;
            }
        }
        
        private Vector2 _Position = Vector2.Zero;
        public Vector2 Position
        {
            get 
            {
                return this._Position;
            }
            set 
            {
                this._Position = value;
            } 
        }
        
        private Vector2 _Origin = Vector2.Zero;
        public Vector2 Origin
        {
            get
            {
                return this._Origin;
            }
            set
            {
                this._Origin = value;
            }
        }

        private float _Opacity = 1f;
        public float Opacity 
        {
            get
            {
                return _Opacity;
            }

            set
            {
                _Opacity = value;
            }
        }
        
        public float Rotation { get; set; }
        
        private SpriteEffects _SpriteEffect = SpriteEffects.None;
        public SpriteEffects SpriteEffect
        {
            get
            {
                return _SpriteEffect;
            }

            set
            {
                _SpriteEffect = value;
            }
        }
        
        public Rectangle Rectangle
        {
            get 
            {
                return new Rectangle(
                    Convert.ToInt32(this.Position.X), 
                    Convert.ToInt32(this.Position.Y), 
                    Convert.ToInt32(this.Size.X), 
                    Convert.ToInt32(this.Size.Y)
                );
            }
        }
        
        public float speedX { get; set; }
        public float speedY { get; set; }
        
        private Boolean _IsAlive = true;
        public Boolean IsAlive
        {
            get
            {
                return _IsAlive;
            }

            set
            {
                _IsAlive = value;
            }
        }

        /// <summary>
        /// Load content loads the texture for the sprite.
        /// For classes that will load content other than Texture2D
        /// Do not call the base and load the content on your own.
        /// </summary>
        /// <param name="ContentManager"></param>
        public virtual void LoadContent(ContentManager ContentManager)
        {
            this.Texture = ContentManager.Load<Texture2D>(this.ID);
            if (this.Size.X == 0 && this.Size.Y == 0)
            {
                Vector2 s = new Vector2(this.Texture.Bounds.Width, this.Texture.Bounds.Height);
                this.Size = s;
            }
        }

        /// <summary>
        /// The function of update at the base is to move the sprite based on its current speed values.
        /// It is probably a good idea to call this before other update logic that would perform collission detection.
        /// If speed(X,Y) is 0, this object does not move.
        /// </summary>
        /// <param name="device">GraphicsDevice: Current GraphicsDevice for the game</param>
        public virtual void Update(GraphicsDevice device)
        {
            //Move the sprite based on the current speed.
            Vector2 pos = this.Position;
            pos.X = pos.X + speedX;
            pos.Y = pos.Y + speedY;            
            this.Position = pos;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        { 
            
        }

    }
}
