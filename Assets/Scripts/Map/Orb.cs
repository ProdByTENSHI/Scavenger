using DG.Tweening;
using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField] private AudioClip CollectClip;
    
    private Transform playerTransform;
    
    private const int MIN_VALUE = 1;
    private const int MAX_VALUE = 3;

    private int value;

    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void OnEnable()
    {
        value = Random.Range(MIN_VALUE, MAX_VALUE);
        transform.localScale = new Vector3(value * 0.5f, value * 0.5f, 1f);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        transform.DOMove(playerTransform.position, 0.75f)
            .SetAutoKill(false);
        if (Vector2.Distance(playerTransform.position, transform.position) <= 1f)
        {
            AudioSource.PlayClipAtPoint(CollectClip, transform.position);
            Destroy(gameObject);
        }
    }
}