using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_DoubleSpiral : MonoBehaviour
{
    public float bulletForce = 2.0f;

    private float angle = 0f;

    private Vector2 bulletMoveDirection;

    public void StartPattern()
    {
        InvokeRepeating("Fire", 0f, 0.1f);
    }

    public void StopPattern()
    {
        CancelInvoke("Fire");
    }

    private void Fire()
    { 
        for (int i = 0; i < 2 ; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bullet = BulletManager.instance.CreateBullet("e_bullet_1");
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            bullet.GetComponent<Rigidbody2D>().velocity = bulDir * bulletForce;

        }

        angle += 10f;

        if (angle >= 360f)
            angle = 0;
    }
}
