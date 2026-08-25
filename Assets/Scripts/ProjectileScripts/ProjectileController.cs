using UnityEngine;

public class ProjectileController : MonoBehaviour
{   
    [SerializeField] private Rigidbody2D rb2D;
    public ProjectileLive projectileLive {  get; private set; }
    public ProjectileDamage projectileDamage { get; private set; }
    public ProjectileShoot projectileShoot { get; private set; }

    private void Awake()
    {
        InitializeComponent();
        SetRigidbody2D();
    }

    private void Update()
    {
        projectileLive.CheckTimeLive();
    }

    #region Set features
    private void SetSpeed(float speed)
    {
       projectileShoot.SetSpeed(speed);
    }

    private void SetDamage(int damage)
    {
       projectileDamage.SetDamage(damage);
    }

    private void SetPool(ObjectPool objectPool)
    {
        projectileLive.SetObjectPool(objectPool);
    }

    public void PrepareBeforeShoot(float speed, int damage, ObjectPool objectPool)
    {
        InitializeComponent();
        SetRigidbody2D();
        SetSpeed(speed);
        SetDamage(damage);
        SetPool(objectPool);
    }
    #endregion

    private void InitializeComponent() 
    {
        projectileLive = GetComponent<ProjectileLive>();
        projectileDamage = GetComponent<ProjectileDamage>();
        projectileShoot = GetComponent<ProjectileShoot>();
    }

    private void SetRigidbody2D() 
    {
        projectileLive.SetRB2D(this.rb2D);
        projectileShoot.SetRB2D(this.rb2D);
    }
}