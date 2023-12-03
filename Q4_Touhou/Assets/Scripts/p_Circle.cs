using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_Circle : MonoBehaviour
{
    public int bulletAmount = 20;
    public float bulletForce = 4f;

    public float startAngle = 0f;
    public float endAngle = 360;

    private Vector2 bulletMoveDirection;

    public void StartPatternRepeating(float delay)
    {
        InvokeRepeating("Fire", 0f, delay);
    }

    public void StartPattern()
    {
        Fire();
    }

    public void StopPattern()
    {
        CancelInvoke("Fire");
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletAmount; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bullet = BulletManager.instance.CreateBullet("e_bullet_1");
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            bullet.GetComponent<Rigidbody2D>().velocity = bulDir * bulletForce;

            angle += angleStep;
        }
    }
}
