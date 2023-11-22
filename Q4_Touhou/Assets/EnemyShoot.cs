using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] Transform canon;
    public float shootforce;

    private Transform enemyTransform;
    private Animator animator;
    private Vector3 positionFix = new Vector3(0, 90, 90);

    private Vector2 shootDirection;

    //Pattern 2
    private List<Vector3> spawnBulletPosition;



    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyTransform = transform;
        spawnBulletPosition = new List<Vector3>();
        /**********To delete**********/
        animator.SetInteger("Pattern", 2);
        /*****************************/
    }

    public void Shoot()
    {
        GameObject bullet = BulletManager.instance.CreateBullet();
        bullet.transform.position = canon.position;
        bullet.transform.LookAt(enemyTransform.position);
        bullet.transform.Rotate(positionFix);

        shootDirection = canon.position - enemyTransform.position;

        bullet.GetComponent<Rigidbody2D>().velocity = shootDirection.normalized * shootforce;
    }

    public void DefinePositionBullet()
    {
        spawnBulletPosition.Add(canon.position);
    }

    public void ClearBulletPositionListToSpawn()
    {
        spawnBulletPosition.Clear();
    }

    public void ShootBulletsPattern2()
    {
        for (int i = 0; i < spawnBulletPosition.Count; i++)
        {
            GameObject bullet = BulletManager.instance.CreateBullet();
            bullet.transform.position = spawnBulletPosition[i];
            bullet.transform.LookAt(enemyTransform.position);
            bullet.transform.Rotate(positionFix);

            shootDirection = spawnBulletPosition[i] - enemyTransform.position;

            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection.normalized * shootforce;
        }
    }


}
