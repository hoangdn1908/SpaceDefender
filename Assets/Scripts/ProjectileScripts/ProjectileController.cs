using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float timeLive;
    [SerializeField] private Rigidbody2D rb2D;
    private float timer;
    private float speed;
    private int damage;
    private ObjectPool projectilePool;

    private void Update()
    {
        CheckTimeLive();
    }

    #region Set features
    private void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    private void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public int GetDamage()
    {
        return this.damage;
    }

    private void SetPool(ObjectPool objectPool)
    {
        this.projectilePool = objectPool;
    }

    public void PrepareBeforeShoot(float speed, int damage, ObjectPool objectPool)
    {
        SetSpeed(speed);
        SetDamage(damage);
        SetPool(objectPool);
    }
    #endregion

    public void Shoot(Vector2 direction) 
    {
        rb2D.linearVelocity = direction.normalized * speed;
    }

    private void CheckTimeLive()
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