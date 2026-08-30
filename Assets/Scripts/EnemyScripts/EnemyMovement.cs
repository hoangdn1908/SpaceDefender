using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private WaypointPath path;
    private float speed;
    private float rotationSpeed;
    private int currentWaypointIndex;

    private void Update()
    {
        MoveToWaypoint();
    }

    public void SetSpeed(float speed) 
    {
        this.speed = speed;
    }

    public void SetRotationSpeed(float rotationSpeed) 
    {
        this.rotationSpeed = rotationSpeed;
    }

    private void MoveToWaypoint() 
    {
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
        Debug.Log("Done");
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
