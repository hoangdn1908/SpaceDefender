using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    [SerializeField] private ProjectileController projectileController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            float damage = projectileController.GetDamage();
            Debug.Log(damage);
            projectileController.ReturnToPool();
        }
    }
}
