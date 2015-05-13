using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ShakeOfTheDay.Helpers;
using ShakeOfTheDay.Sprites;
using System;
using System.Linq;

namespace ShakeOfTheDay
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class ShakeOfTheDay : Game_Base
    {
        public Int32 ShakeNumber = 0;

        private Boolean pauseKeyStillPressed = false;
        private Boolean adminKeyStillPressed = false;
        private Random rnd = new Random();

        public ShakeOfTheDay()
        {           
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here            
            base.Initialize();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
            this.stateManager.State = States.WalkingDice;
            ShakeNumber = rnd.Next(1, 6);
            stateManager.shakeNumber = ShakeNumber;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            base.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            #region Pause Button Handler
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed
                || Keyboard.GetState().GetPressedKeys().ToList().Contains(Keys.P))
            {
                if (!pauseKeyStillPressed)
                {
                    if (this.stateManager.State == States.Pause)
                    {
                        this.stateManager.State = States.WalkingDice;
                    }
                    else
                    {
                        this.stateManager.State = States.Pause;
                    }
                }
                pauseKeyStillPressed = true;
            }

#if XBOX
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Released && pauseKeyWasPressed)
            {
                pauseKeyStillPressed = false;
            }
#else
            if (Keyboard.GetState().IsKeyUp(Keys.P) && pauseKeyStillPressed)
            {
                pauseKeyStillPressed = false;                
            }
#endif

            #endregion

            #region Admin Button Handler
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().GetPressedKeys().ToList().Contains(Keys.O))
            {
                if (!adminKeyStillPressed)
                {
                    if (this.stateManager.State == States.Admin)
                    {
                        this.stateManager.State = States.WalkingDice;
                    }
                    else
                    {
                        this.stateManager.State = States.Admin;
                    }
                }
                adminKeyStillPressed = true;
            }

#if XBOX
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Released && adminKeyStillPressed)
            {
                adminKeyStillPressed = false;
            }
#else
            if (Keyboard.GetState().IsKeyUp(Keys.O) && adminKeyStillPressed)
            {
                adminKeyStillPressed = false;
            }
#endif

            #endregion

            #region Update Sprites
            if (this.stateManager.State != States.Pause && this.stateManager.State != States.Admin)
            {
                (layerManager.GetAllSprites().ToList()).ForEach(x => x.Update(GraphicsDevice));
            }
            #endregion

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {  
            base.Draw(gameTime);
        }
    }
}
