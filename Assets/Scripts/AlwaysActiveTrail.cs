using UnityEngine;

public class SimulatedMotionTrail : MonoBehaviour
{
    public TrailRenderer trailRenderer;
    private Vector3 offset = Vector3.one * 0.1f; // Small offset

    void Update()
    {
        transform.position += offset;
        offset = -offset; // Alternate offset direction to prevent drift
    }
}