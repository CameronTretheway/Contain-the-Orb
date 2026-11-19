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
        float score = 0;

        public int modifier = 0;

        float highScore = 0;

        Ball[] balls = new Ball[2];
        public void Setup()
        {
            Window.SetTitle("Contain the Orb");
            Window.SetSize(1000, 1000);
            Window.ClearBackground(Color.Black);

            balls[0] = new Ball();
            balls[0].Setup(50, 0);

            balls[1] = new Ball();
            balls[1].Setup(30, 1);

        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.Black);
            Text.Color = Color.White;
            Text.Draw($"MOTES: {score}", 10, 10);

            

            for (int i = 0; i < balls.Length; i += 1)
            {
             
                balls[i].TryCollideWithOtherBalls(balls);

                CheckForLoss();



            }

            for (int i = 0; i < balls.Length; i++)
            {
                
                balls[i].Update(); 
     
            }

            if (score >= highScore)
            {
                highScore = score;
            }

            if (balls[0].internalLossDetector == true)
            {
                if (Input.IsMouseButtonDown(MouseButton.Left))
                {
                    score = 0;
                    balls[0].Reset(true);
                }
            }

        } 

        void CheckForLoss()
        {
            if (balls[0].internalLossDetector == false)
            {
                score += Time.DeltaTime * 1; 
            }
            else
            {
                Text.Draw($"THE ORB ESCAPED. YOU LOSE.", 270, 500);

                Text.Draw($"HIGHEST YIELD: {highScore}", 300, 600);

                Text.Draw($"CLICK TO TRY AGAIN.", 330, 700);
            }
        }
    }
}