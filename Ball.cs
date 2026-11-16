using System;
using System.Numerics;

namespace MohawkGame2D;

public class Ball
{
    Vector2 position;
    Vector2 velocity;
    float Radius;
    float friction = 0.7f;

    public void Setup()
    {
        
        position = Random.Vector2(Window.Size);

        Radius = Random.Integer(10, 30 + 1);

        


    }

    public void Update()
    {

        Vector2 gravity = new Vector2(0, 10);

        velocity += gravity * Time.DeltaTime;

        position += velocity;

    
        bool isCollidingTop = (position.Y - Radius) < 0;
        bool isCollidingBottom = (position.Y + Radius) > Window.Height;
        bool isCollidingLeft = (position.X - Radius) < 0;
        bool isCollidingRight = (position.X + Radius) > Window.Width;

      
        if (isCollidingBottom == true)
        {
      
            position.Y = Window.Height - Radius;
   
            velocity.Y = -velocity.Y;
        }
    
        if (isCollidingTop == true)
        {
            position.Y = 0 + Radius;
            velocity.Y = -velocity.Y;
        }

   
        if (isCollidingLeft == true)
        {
            position.X = 0 + Radius;
            velocity.X = -velocity.X;
        }
       
        if (isCollidingRight == true)
        {
            position.X = Window.Width - Radius;
            velocity.X = -velocity.X;
        }

     
        if (isCollidingBottom || isCollidingLeft || isCollidingRight)
        {
           
            velocity *= friction;
        }


    }

    public void TryCollideWithOtherBalls(Ball[] balls)
    {
       

        foreach (Ball other in balls)
        {
            
            if (this == other)
                continue;
        
            float sumRadii = this.Radius + other.Radius;
          
            Vector2 fromThisToOther = other.position - this.position;
            Vector2 direction = Vector2.Normalize(fromThisToOther);
            float distance = fromThisToOther.Length();

         
            bool doOverlap = distance < sumRadii;
            if (doOverlap == true)
            {
               
                float halfDistance = (sumRadii - distance) / 2;
                Vector2 displacement = direction * halfDistance;
                
                other.position += displacement;
              
                this.position -= displacement;

               
                float volumeThis = MathF.PI * this.Radius * this.Radius;
                float volumeOther = MathF.PI * other.Radius * other.Radius;
                float sumVolume = volumeThis + volumeOther;
                float frictionThis = 1f - (volumeThis / sumVolume * (1 - friction));
                float frictionOther = 1f - (volumeOther / sumVolume * (1 - friction));

           
                this.velocity = this.velocity.Length() * -direction * frictionThis;
                other.velocity = other.velocity.Length() * +direction * frictionOther;
            }
        }
    }
}
