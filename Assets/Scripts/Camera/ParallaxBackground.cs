using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float Parallax;

    private Camera cam;
    private SpriteRenderer sr;
    
    private float length;
    private float startPos;

    private void Awake()
    {
        cam = Camera.main;
        sr = GetComponent<SpriteRenderer>();
        
        startPos = transform.position.x;
        length = sr.bounds.size.x;
    }

    private void Update()
    {
        float temp = (cam.transform.position.x * (1 - Parallax));
        float distance = cam.transform.position.x * Parallax;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + length)
            startPos += length;
        else if (temp < startPos - length)
            startPos -= length;
    }
}