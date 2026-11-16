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

        Ball[] balls = new Ball[2];
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

            
            for (int i = 0; i < balls.Length; i += 1)
            {
             
                balls[i].TryCollideWithOtherBalls(balls); 
            }


            
            for (int i = 0; i < balls.Length; i++)
            {
                
                balls[i].Update();
            }
        } 
    }
}