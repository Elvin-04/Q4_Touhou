using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shootPerSecond = 10;
    public Vector2 shootForce;

    public List<Transform> shootPoints;
    public GameObject bulletPrefab;

    private Vector3 fixRotation = Vector3.zero;

    private void Start()
    {
        StartCoroutine(TimeBetweenShoot());
    }


    IEnumerator TimeBetweenShoot()
    {
        yield return new WaitForSeconds(1 / shootPerSecond);
        /***************************************************/
        for (int i = 0; i < shootPoints.Count; i++)
        {
            GameObject bullet = BulletManager.instance.CreateBullet();
            bullet.transform.position = shootPoints[i].transform.position;
            bullet.transform.rotation = Quaternion.Euler(fixRotation);
            bullet.GetComponent<Rigidbody2D>().velocity = shootForce;
        }
        /***************************************************/
        StartCoroutine(TimeBetweenShoot());
    }
}
