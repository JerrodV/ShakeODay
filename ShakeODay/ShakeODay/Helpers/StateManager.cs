using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using ShakeOfTheDay.AnimatedSprites;
using ShakeOfTheDay.FontSprites;
using ShakeOfTheDay.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShakeOfTheDay.Helpers
{
    public enum States
    { 
        WalkingDice,
        DisplayNumber,
        Admin,
        Pause
    }


    public class StateManager
    {
        public Game_Base game;
        public Int32 shakeNumber;
        public States _State = States.WalkingDice;
        public States State 
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
                StateLoaded = false;
                switch (value)
                { 
                    case States.Admin:
                        loadAdmin();
                        break;
                    case States.DisplayNumber:
                        LoadDisplayNumber();
                        break;
                    case States.Pause:
                        LoadPause();
                        break;
                    case States.WalkingDice:
                        LoadWalkingDice();
                        break;
                }
            }
        }

        public Boolean StateLoaded { get; set; }

        public ContentManager contentManager { get; set; }
        public GraphicsDeviceManager deviceManager { get; set; }
        public LayerManager layerManager { get; set; }

        public StateManager(Game_Base game)
        {
            this.game = game;
            this.contentManager = game.Content;
            this.deviceManager = game.graphics;
            this.layerManager = game.layerManager;
        }

        public void loadAdmin()
        {
            loadModalOverlay();
        }

        public void LoadDisplayNumber()
        {
            this.layerManager.Clear();
            layerManager.Layers[(int)Gamelayers.UI].Sprites.Add(new ShakeOfTheDayAnimation(this, this.shakeNumber));
        }

        public void LoadPause()
        {
            loadModalOverlay();
            FontSprite ani = new FontSprite(this);
            ani.ID = "Georgia";
            ani.Text = new StringBuilder("Pause");
            ani.Scale = .3f;
            ani.Color = Color.White;
            ani.LoadContent(this.contentManager);
            ani.Position = new Vector2(
                        (this.deviceManager.PreferredBackBufferWidth / 1.8f) - (ani.SpriteFont.MeasureString(ani.Text).X * ani.Scale),
                        (this.deviceManager.PreferredBackBufferHeight / 2.5f));
            this.layerManager.Layers[(int)Gamelayers.UI].Sprites.Add(ani);
        }

        public void LoadWalkingDice()
        {
            this.layerManager.Clear();
            layerManager.Layers[(int)Gamelayers.Background].Sprites.Add(new WalkingDice(this));
            layerManager.Layers[(int)Gamelayers.UI].Sprites.Add(new SnuffysString(this));
            layerManager.Layers[(int)Gamelayers.UI].Sprites.Add(new ShakeOfTheDayString(this));
        }

        private void loadModalOverlay()
        {
            ModalForground mf = new ModalForground(this);
            this.layerManager.Layers[(int)Gamelayers.UI].Sprites.Add(mf);
        }
    }
}
