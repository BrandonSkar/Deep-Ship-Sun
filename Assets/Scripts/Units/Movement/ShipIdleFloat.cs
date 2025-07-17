using UnityEngine;

public class ShipIdleFloat : MonoBehaviour
{
    [Header("Drift Settings")]
    public float driftAmplitude = 0.05f; // Side-to-side movement
    public float driftFrequency = 0.3f;  // Speed of the drift

    [Header("Tilt Settings")]
    public float tiltAmplitude = 2f;     // Degrees to rotate side to side
    public float tiltFrequency = 0.2f;   // Speed of the tilt

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        float drift = Mathf.Sin(Time.time * driftFrequency) * driftAmplitude;
        float tilt = Mathf.Sin(Time.time * tiltFrequency) * tiltAmplitude;

        transform.position = initialPosition + transform.right * drift;
        transform.rotation = Quaternion.Euler(0, 0, tilt); // Z-axis for 2D top-down tilt
    }
}
