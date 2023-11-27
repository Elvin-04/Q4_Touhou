using UnityEngine;

public class MapCollider : MonoBehaviour
{
    //Layer 6 = Bullet
    //Layer 8 = player bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6
            || collision.gameObject.layer == 8)
        {
            BulletManager.instance.DestroyBullet(collision.gameObject);
        }
    }
}
