using Unity.VisualScripting;
using UnityEngine;

public class GrowBiggerBullet : MonoBehaviour
{
    public float initialScale = 0.15f;
    public float maximalScale = 0.7f;
    public float timeToGrowBigger = 2.0f;
    public float force = 2.6f;

    private Vector2 maxScale;
    private Vector2 velocity;

    private void OnEnable()
    {
        maxScale.Set(maximalScale, maximalScale);
        transform.localScale = new Vector2(initialScale, initialScale);
    }

    private void FixedUpdate()
    {
        transform.localScale = Vector2.SmoothDamp(transform.localScale, maxScale, ref velocity, timeToGrowBigger);
    }
}
