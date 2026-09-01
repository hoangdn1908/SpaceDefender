using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class PathVisualizer : MonoBehaviour
{
    [SerializeField] private WaypointPath waypointPath;
    [SerializeField] private LineRenderer lineRenderer;
    //[SerializeField] private float pathWidth = 1.5f;
    //[SerializeField] private float textureTiling = 1f;
    [SerializeField] private float scrollSpeed = 1f;

    private void Awake()
    {
        SetupLineRenderer();
        UpdatePath();
    }

    private void Update()
    {
        ScrollTexture();
    }

    private void SetupLineRenderer()
    {
        lineRenderer.positionCount = waypointPath.WaypointCount;
    }

    private void UpdatePath()
    {
        for (int i = 0; i < waypointPath.WaypointCount; i++)
        {
            Transform waypoint = waypointPath.GetWaypoint(i);
            lineRenderer.SetPosition(i, waypoint.position);
        }
    }

    private void ScrollTexture() 
    {
        lineRenderer.material.mainTextureOffset -= new Vector2(Time.deltaTime * scrollSpeed, 0f);
    }
}
