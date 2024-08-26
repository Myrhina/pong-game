using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    public float bounceStrength;
    public float velocityIncreasePercentage = 0.05f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * this.bounceStrength);

            Vector2 velocity = ballRigidbody.velocity;
            velocity.x += velocity.x * velocityIncreasePercentage;
            ballRigidbody.velocity = velocity;
        }
    }
}
