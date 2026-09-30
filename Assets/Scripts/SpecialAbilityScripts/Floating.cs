using UnityEngine;

public class Floating : MonoBehaviour
{
    [Header("Floating")]
    [SerializeField] private float floatHeight = 0.5f;
    [SerializeField] private float floatSpeed = 1f;

    [Header("Drifting")]
    [SerializeField] private float driftAmount = 0.2f;
    [SerializeField] private float driftSpeed = 0.5f;

    [Header("Rotation")]
    [SerializeField] private float rotationAmount = 5f;
    [SerializeField] private float rotationSpeed = 0.5f;

    private Vector3 startPosition;
    private float noiseOffset;

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        UpdateFloating();
    }

    private void Initialize()
    {
        startPosition = transform.position;
        noiseOffset = Random.Range(0f, 100f);
    }

    private void UpdateFloating()
    {
        float time = Time.time;
        Vector3 position = CalculateFloatingPosition(time);
        float rotation = CalculateRotation(time);
        ApplyPosition(position);
        ApplyRotation(rotation);
    }

    private Vector3 CalculateFloatingPosition(float time)
    {
        float verticalOffset = CalculateNoise( noiseOffset, time, floatSpeed, floatHeight);
        float horizontalOffset = CalculateNoise( noiseOffset + 100f, time, driftSpeed, driftAmount);
        return startPosition + new Vector3(horizontalOffset, verticalOffset, 0f);
    }

    private float CalculateRotation(float time)
    {
        return CalculateNoise( noiseOffset + 200f, time, rotationSpeed, rotationAmount);
    }

    private float CalculateNoise(float offset, float time, float speed, float amount)
    {
        float noise = Mathf.PerlinNoise(offset, time * speed);
        return (noise - 0.5f) * 2f * amount;
    }

    private void ApplyPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void ApplyRotation(float rotation)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }
}
