using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 Offset;
    [SerializeField] private float Smoothness;

    private Transform playerTransform;
    private Vector2 velocity;
    private float initZPos;

    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z) - Offset;
        initZPos = transform.position.z;
    }

    private void LateUpdate()
    {
        Vector3 target = playerTransform.position - Offset;
        Vector2 smoothed = Vector2.SmoothDamp(transform.position, target, ref velocity, Smoothness);
        
        transform.position = new Vector3(smoothed.x, smoothed.y, initZPos);
    }
}