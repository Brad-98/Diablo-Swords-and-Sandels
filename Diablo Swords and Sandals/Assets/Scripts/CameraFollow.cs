using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetPlayer;

    private Vector3 cameraOffset;

    [SerializeField]
    private float SmoothFactor = 1.0f;

    void Start()
    {
        cameraOffset = transform.position - targetPlayer.position;    
    }

    void LateUpdate()
    {
        Vector3 newPosition = targetPlayer.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPosition, SmoothFactor);

        transform.LookAt(targetPlayer);
    }
}
