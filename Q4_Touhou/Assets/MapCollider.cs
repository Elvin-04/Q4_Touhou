using UnityEngine;

public class MapCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "PlayerBullet")
        {
            BulletManager.instance.DestroyBullet(collision.gameObject);
        }
    }
}
