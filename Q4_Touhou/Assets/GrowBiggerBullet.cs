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
    private Transform myTransform;


    private void OnEnable()
    {
        myTransform = transform;
        maxScale.Set(maximalScale, maximalScale);
        myTransform.localScale = new Vector2(initialScale, initialScale);
    }

    private void FixedUpdate()
    {
        myTransform.localScale = Vector2.SmoothDamp(myTransform.localScale, maxScale, ref velocity, timeToGrowBigger);
    }
}
