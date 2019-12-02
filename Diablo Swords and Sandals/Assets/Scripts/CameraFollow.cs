using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    void LateUpdate()
    {
        Vector3 newPosition = targetPlayer.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPosition, SmoothFactor);

        transform.LookAt(targetPlayer);
    }
}
