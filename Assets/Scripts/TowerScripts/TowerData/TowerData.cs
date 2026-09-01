using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Scriptable Objects/TowerData")]
public class TowerData : ScriptableObject
{
    [Header("Projectile Data")]
    public float projectileSpeed;
    public int projectileDamage;
    [Header("Projectile Size")]
    public float scaleX;
    public float scaleY;
    [Header("Tower Data")]
    public float timeRate;
    public float detectRange;
    public Sprite towerImage;
}
