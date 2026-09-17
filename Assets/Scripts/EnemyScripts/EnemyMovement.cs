using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;
    private WaypointPath path;
    private float speed;
    private float rotationSpeed;
    private int currentWaypointIndex;

    private void Update()
    {
        MoveToWaypoint();
    }

    #region Setter
    public void SetSpeed(float speed) 
    {
        this.speed = speed;
    }

    public void SetRotationSpeed(float rotationSpeed) 
    {
        this.rotationSpeed = rotationSpeed;
    }

    public void SetPath(WaypointPath waypointPath) 
    {
        this.path = waypointPath;
    }

    public void ResetCurrentWayPointIndex() 
    {
        currentWaypointIndex = 0;
    }
    #endregion

    private void MoveToWaypoint()
    {
        if (this.path == null) return;
        Transform waypointTarget = path.GetWaypoint(currentWaypointIndex);
        if (waypointTarget == null) return;
        Vector2 direction = waypointTarget.position - transform.position;
        FlipByDirection(direction);
        transform.position = Vector3.MoveTowards(transform.position, waypointTarget.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, waypointTarget.position) < 0.01f) 
        {
            GoToNextWaypoint();
        }
    }

    private void GoToNextWaypoint() 
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= path.WaypointCount) 
        {
            ReachGoal();
        }
    }

    private void ReachGoal() 
    {
        GameEvents.RaiseEnemyFinished(this.enemyController);
        GameEvents.RaiseEnemyReachGoal(this.enemyController.enemyData.damage);
        enemyController.enemyLive.ReturnToPool();
    }

    private void FlipByDirection(Vector2 direction) 
    {
        if (direction.sqrMagnitude > 0.01f) 
        {
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            float currentAngle = transform.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
    }
}
