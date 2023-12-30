using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    [SerializeField] private float Speed;

    private void Update()
    {
        transform.position += new Vector3(Speed, 0f, 0f) * Time.deltaTime;
    }
}