using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShakeOfTheDay.Helpers;
using ShakeOfTheDay.AnimatedSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShakeOfTheDay.FontSprites
{
    public class ShakeOfTheDayAnimation : FontSprite
    {
        enum AnimationStates
        { 
            TextMovingUp,
            ShowNumber,
            FlashNumber,
            SlideOutText
        }
        Int32 shakeNumber;
        private AnimationStates animationState { get; set; }
        private Boolean todayShown { get; set; }
        private Boolean numberShown { get; set; }
        private Int32 blinkCount = 20;
        private Int32 currentBlink = 0;
        private DateTime blinkStartTime { get; set; }
        private Boolean isFadingIn { get; set; }

        public ShakeOfTheDayAnimation() { }
        public ShakeOfTheDayAnimation(StateManager stateManager, Int32 shakeNumber)
        {
            
            this.stateManager = stateManager;
            this.shakeNumber = shakeNumber;
            this.ID = "Georgia";
            this.Text = new StringBuilder("Shake of the Day");
            this.Color = Color.Red;
            this.Scale = .7f;
            this.speedY = -3;
            this.animationState = AnimationStates.TextMovingUp;
            this.LoadContent(stateManager.contentManager);
            this.Position = new Vector2(
                        (((stateManager.deviceManager.PreferredBackBufferWidth / 2) - (this.SpriteFont.MeasureString(this.Text).X / 2) * Scale)),
                        float.Parse((stateManager.deviceManager.PreferredBackBufferHeight / 1.5).ToString()));

        }

        public override void LoadContent(ContentManager ContentManager)
        {
            base.LoadContent(ContentManager);
        }

        public override void Update(GraphicsDevice device)
        {
            base.Update(device);
            switch (animationState)
            { 
                case AnimationStates.TextMovingUp:
                    if (this.Position.Y <= stateManager.deviceManager.PreferredBackBufferHeight * .1)
                    {
                        this.speedY = 0;
                        animationState = AnimationStates.ShowNumber;
                    }
                    this.Scale += .0015f;
                    Vector2 pos = this.Position;
                    pos.X = float.Parse((pos.X - .9).ToString());
                    this.Position = pos;
                    break;
                case AnimationStates.ShowNumber:
                    if (!todayShown)
                    {
                        stateManager.layerManager.Layers[(int)Gamelayers.GameArea8].Sprites.Add(new TodaysNumberString(this.stateManager));
                        todayShown = true;
                    }
                    TodaysNumberString anim = stateManager.layerManager.GetSpritesByType<TodaysNumberString>()[0] as TodaysNumberString;
                    anim.Scale += .005f;  
                    Vector2 animPos = anim.Position;
                    animPos.X = float.Parse((animPos.X - 3.5).ToString());
                    anim.Position = animPos;

                    if (anim.Scale > .5)
                    {
                        animationState = AnimationStates.FlashNumber;
                    }
                    break;
                case AnimationStates.FlashNumber:
                    if (!numberShown)
                    {
                        ShakeNumber sn = new ShakeNumber(this.stateManager);
                        sn.Text = new StringBuilder(this.shakeNumber.ToString());
                        stateManager.layerManager.Layers[(int)Gamelayers.GameArea8].Sprites.Add(sn);
                        numberShown = true;
                        blinkStartTime = DateTime.Now;

                        SpinningDice sdLeft = new SpinningDice(this.stateManager);
                        sdLeft.Position = new Vector2
                        (
                            (stateManager.deviceManager.PreferredBackBufferWidth * .15f) - (sdLeft.DisplaySize.X / 2),
                            (stateManager.deviceManager.PreferredBackBufferHeight / 2) - (sdLeft.DisplaySize.Y / 2)
                        );
                        stateManager.layerManager.Layers[(int)Gamelayers.GameArea8].Sprites.Add(sdLeft);

                        SpinningDice sdRight = new SpinningDice(this.stateManager);
                        sdRight.playReverse = true;
                        sdRight.Position = new Vector2
                        (
                            (stateManager.deviceManager.PreferredBackBufferWidth * .80f) - (sdRight.DisplaySize.X / 2),
                            (stateManager.deviceManager.PreferredBackBufferHeight / 2) - (sdRight.DisplaySize.Y / 2)
                        );
                        stateManager.layerManager.Layers[(int)Gamelayers.GameArea8].Sprites.Add(sdRight);
                    }

                    TimeSpan ts = DateTime.Now - blinkStartTime;

                    if (ts.TotalMilliseconds > 100)
                    {
                        ShakeNumber uSn = stateManager.layerManager.GetSpritesByType<ShakeNumber>()[0] as ShakeNumber;

                        if (isFadingIn)
                        {
                            uSn.Opacity += .1f;
                            if (uSn.Opacity >= 1)
                            {
                                isFadingIn = false;
                                currentBlink++;
                                blinkStartTime = DateTime.Now;
                            }
                        }
                        else
                        {
                            uSn.Opacity -= .1f;
                            if (uSn.Opacity <= 0)
                            {
                                isFadingIn = true;
                            }
                        }

                        if (currentBlink == blinkCount)
                        {
                            this.stateManager.State = States.WalkingDice;
                            this.IsAlive = false;
                        }
                    }
                    break;

            }
            
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {           
            base.Draw(spriteBatch);
        }
    }
}
