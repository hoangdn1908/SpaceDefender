using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Transform buildPoint;

    public Vector3 BuildPosition => buildPoint.position;

    private bool isOccupied;
    public bool IsOccupied => isOccupied;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (isOccupied) return;
        GameEvents.RaisePlatformSelected(this);
    }

    public void SetOccupied(bool value)
    {
        isOccupied = value;
    }
}