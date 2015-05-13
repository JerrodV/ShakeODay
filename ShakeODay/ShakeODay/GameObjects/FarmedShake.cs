using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShakeOfTheDay.GameObjects
{
    /// <summary>
    /// <para>Controls the shake of the day dice rolling game.</para>
    /// <para>To preserve the integrity of the game rules, the allowed usage is very limited.</para>
    /// <para>Only one </para>
    /// </summary>
    public class FarmedShake
    {
        public Int32 MaxShakes { get; private set; }
        public Int32 ShakeTarget { get; private set; }

        private const Int32 boxSize = 5;
        public Int32[] DiceBox;
        public Int32[] DiceFarm;        
        public Int32 CurrentShake = 0;

        /// <summary>
        /// Constructs a new instance of the FarmedShake class.
        /// </summary>
        /// <param name="MaxShakes">The max allowed number of shakes the player can attempt on this instance.</param>
        /// <param name="ShakeTarget">The ShakeOfTheDay target number</param>
        public FarmedShake(Int32 MaxShakes, Int32 ShakeTarget) 
        { 
            this.MaxShakes = MaxShakes;
            this.ShakeTarget = ShakeTarget;
        }

        /// <summary>
        /// This should be the first call after the object is created.
        /// It will initialize the arrays and fill the DiceBox with new random numbers to farm from
        /// </summary>
        public void Roll()
        {
            Random rnd = new Random();
            DiceBox = new Int32[boxSize];
            for (int i = 0; i < boxSize; i++)
            {
                DiceBox[i] = rnd.Next(1, 6);
            }
            DiceFarm = new Int32[boxSize];
            CurrentShake++;
        }       

        /// <summary>
        /// Moves the dice who match the shake target to the farm and removes the dice from the box(Sets to 0).
        /// </summary>
        /// <param name="index">Position in the DiceBox to DiceFarm</param>
        public void FarmDice()
        {
            for (int i = 0; i < boxSize; i++)
            {
                if (DiceFarm[i] == ShakeTarget)
                {
                    DiceFarm[i] = ShakeTarget;
                    DiceBox[i] = 0;
                }
            }
        }

        /// <summary>
        /// Use after the initial Roll call.This shakes what is left in the box after the player farms dice.
        /// </summary>
        public void ShakeRemaining()
        {
            if (CurrentShake < MaxShakes)
            {
                Random rnd = new Random();
                for (int i = 0; i < boxSize; i++)
                {
                    if (DiceFarm[i] > 0)
                    {
                        DiceBox[i] = rnd.Next(1, 6);
                    }
                }
                CurrentShake++;
            }
        }
    }
}
