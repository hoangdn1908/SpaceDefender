using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    private float speed;
    private Rigidbody2D rb2D;

    public void SetSpeed(float speed) 
    {
        this.speed = speed;
    }

    public void SetRB2D(Rigidbody2D rb2D) 
    {
        this.rb2D = rb2D;
    }

    public void Shoot(Vector2 direction)
    {
        rb2D.linearVelocity = direction.normalized * speed;
    }
}
