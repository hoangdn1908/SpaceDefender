using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float speed;
    public float rotationSpeed;
    public int maxHealth;
    public float colliderRadius;
    public int damage;
    public int coinEarn;
    public Sprite[] sprites;
    public EnemyType enemyType;
}

public enum EnemyType 
{
    Small,
    Big,
    Boss,
}
