using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private WaypointPath path;
    [SerializeField] private float speed = 5f;
    private int currentWaypointIndex;

    private void Update()
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint() 
    {
        Transform waypointTarget = path.GetWaypoint(currentWaypointIndex);
        if (waypointTarget == null) return;
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
}
