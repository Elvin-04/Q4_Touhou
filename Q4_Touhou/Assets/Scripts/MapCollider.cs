using UnityEngine;

public class MapCollider : MonoBehaviour
{
    //Layer 6 = Bullet

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            BulletManager.instance.DestroyBullet(collision.gameObject);
        }
    }
}
