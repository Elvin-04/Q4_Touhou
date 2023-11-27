using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public float shootPerSecond = 10;
    public Vector2 shootForce;

    public List<Transform> shootPoints;
    public GameObject bulletPrefab;

    private Vector3 fixRotation = Vector3.zero;

    public float timeBeforeFirstShoot = 3.5f;

    bool canShoot = false;


    private void Start()
    {
        StartShoot();
        UIManager.instance.SetCanShootText(canShoot);
    }


    IEnumerator TimeBetweenShoot()
    {
        yield return new WaitForSeconds(1 / shootPerSecond);
        /***************************************************/
        for (int i = 0; i < shootPoints.Count; i++)
        {
            GameObject bullet = BulletManager.instance.CreateBullet("PlayerBullet");
            bullet.transform.position = shootPoints[i].transform.position;
            bullet.transform.rotation = Quaternion.Euler(fixRotation);
            bullet.GetComponent<Rigidbody2D>().velocity = shootForce;
        }
        /***************************************************/
            
        StartCoroutine(TimeBetweenShoot());
    }

    public void StartShoot()
    {
        StartCoroutine(TimeToShootAgain());
    }

    public void StopShoot()
    {
        canShoot = false;
        UIManager.instance.SetCanShootText(canShoot);
        StopAllCoroutines();
    }

    IEnumerator TimeToShootAgain()
    {
        yield return new WaitForSeconds(timeBeforeFirstShoot);
        canShoot = true;
        UIManager.instance.SetCanShootText(canShoot);
    }

    public void Shoot(InputAction.CallbackContext ctx)
    {
        if(ctx.started && canShoot)
        {
            StartCoroutine(TimeBetweenShoot());
        }

        if (ctx.canceled && canShoot)
        {
            StopAllCoroutines();
        }
    }
}
