using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform Transform;
    [SerializeField] private float Radius;
    [SerializeField] private LayerMask GroundLayer;

    public bool IsOnGround()
    {
        return Physics2D.OverlapCircle(Transform.position, Radius, GroundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        if (Transform == null)
            Transform = transform;
        
        Gizmos.DrawWireSphere(Transform.position, Radius);
    }
}