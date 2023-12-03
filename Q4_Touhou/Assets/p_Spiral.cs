using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_Spiral : MonoBehaviour
{
    public float bulletForce = 5f;
    public float angleStep = 5;
    public float delay = 0.1f;

    public float angle = 0f;

    public bool clockwize = true;


    public void StartPattern()
    {
        InvokeRepeating("Fire", 0f, delay);
    }

    public void StopPattern()
    {
        CancelInvoke("Fire");
    }

    private void Fire()
    {
        float bullDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180); ;
        float bullDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180);

        Vector3 bulMoveVector = new Vector3(bullDirX, bullDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        GameObject bullet = BulletManager.instance.CreateBullet("e_bullet_1");
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;

        bullet.GetComponent<Rigidbody2D>().velocity = bulDir * bulletForce;

        if(clockwize)
            angle += angleStep;
        else
            angle -= angleStep;
    }
}
