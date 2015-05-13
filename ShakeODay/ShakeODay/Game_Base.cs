using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShakeOfTheDay.Helpers;
using System.Collections.Generic;
using System.Text;
using ShakeOfTheDay.Sprites;

namespace ShakeOfTheDay
{
    /// <summary>
    /// This is the base type for your game
    /// </summary>
    public class Game_Base : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public LayerManager layerManager;
        public StateManager stateManager;
        public BgGrad bgGrad;

        public Game_Base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";    
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your global initialization logic here
            
            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your global content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
#if DEBUG
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.ApplyChanges();
#else
            //graphics.PreferredBackBufferHeight = 1080;
            //graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.ToggleFullScreen();
            graphics.ApplyChanges();
#endif

            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            layerManager = new LayerManager(10);
            stateManager = new StateManager(this);            
           
            // TODO: use this.Content to load your game global content here
            bgGrad = new BgGrad(this.stateManager);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any global non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || Keyboard.GetState().GetPressedKeys().ToList().Contains(Keys.Escape))
            { this.Exit(); }

            //Clean up sprites that were labled Dead(!IsAlive)
            foreach (Layer l in layerManager.Layers)
            {
                //Remove al lthe dead sprites
                l.Sprites.Where(x => x.IsAlive == false).ToList<Sprite>().ForEach(x => l.Sprites.Remove(x));
            }
            

            // TODO: Add your global update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            bgGrad.Draw(spriteBatch);
            foreach (Layer l in layerManager.Layers)
            {
                
                foreach (Sprite s in l.Sprites)
                {
                    if (s.IsAlive)
                    {
                        s.Draw(spriteBatch);
                    }
                }
            }
            spriteBatch.End();
            // TODO: Add your global drawing code here

            base.Draw(gameTime);
        }
    }
}
