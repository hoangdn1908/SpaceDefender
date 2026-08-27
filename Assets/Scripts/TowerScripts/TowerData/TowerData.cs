using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Scriptable Objects/TowerData")]
public class TowerData : ScriptableObject
{
    [Header("Projectile Value")]
    public float projectileSpeed;
    public int projectileDamage;
    [Header("Projectile Size")]
    public float scaleX;
    public float scaleY;
    [Header("Tower Value")]
    public float timeRate;
    public float detectRange;
}
