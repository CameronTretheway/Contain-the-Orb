// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {   
        int playerXPos = 0 + 800 / 2;
        int playerYPos = 0 + 600 / 2;
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Contain the Orb");
            Window.SetSize(800, 600);
            
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            int score = 0;
            Text.Color = Color.White;
            Text.Draw($"MOTES: {score}", 10, 10); 
        } 
    }
}