using System.Linq.Expressions;
using UnityEngine;

public class ProjectileSize : MonoBehaviour
{
    [SerializeField] private Transform projectileSize;

    public void SetScale(Vector3 scale) 
    {
        projectileSize.localScale = scale;
    }
}
