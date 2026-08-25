using UnityEngine;

public class ProjectileLive : MonoBehaviour
{
    [SerializeField] private float timeLive;
    private Rigidbody2D rb2D;
    private float timer;
    private ObjectPool projectilePool;

    private void OnEnable()
    {
        ProjectileDamage.OnProjectileHit += ReturnToPool;
    }

    private void OnDisable()
    {
        ProjectileDamage.OnProjectileHit -= ReturnToPool;
    }

    public void SetObjectPool(ObjectPool objectPool) 
    {
        this.projectilePool = objectPool;
    }

    public void SetRB2D(Rigidbody2D rb2D)
    {
        this.rb2D = rb2D;
    }

    public void CheckTimeLive()
    {
        timer += Time.deltaTime;
        if (timer >= timeLive)
        {
            timer = 0;
            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        rb2D.linearVelocity = Vector2.zero;
        projectilePool.ReturnToPool(gameObject);
    }
}
