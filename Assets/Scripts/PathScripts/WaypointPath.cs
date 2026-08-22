using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    public int WaypointCount => waypoints.Length;

    public Transform GetWaypoint(int index) 
    {
        if(index >= WaypointCount) return null;
        return waypoints[index];
    }
}
