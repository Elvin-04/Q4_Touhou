using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    public List<int> patterns;
    private int currentPattern;

    private bool isPause = false;

    private EnemyMovements movements;
    private float currentTimer = 0.0f;

    public float TimeByPattern = 12.0f;
    public float pauseBetweenPatterns = 2.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        movements = GetComponent<EnemyMovements>();
        enemyTransform = transform;
        spawnBulletPosition = new List<Vector3>();
    }

    private void FixedUpdate()
    {
        if(!movements.isMoving)
        {
            if (currentTimer == 0.0f)
            {
                ChangePattern(patterns[currentPattern]);
                currentTimer += Time.deltaTime;
            }
            else
            {
                ChangePattern(patterns[currentPattern]);
                if (currentTimer >= TimeByPattern && !isPause)
                {
                    isPause = true;
                    StartCoroutine(TimeBetwwenPattern());
                }
                else
                {
                    currentTimer += Time.deltaTime;
                }
            }
        }

        if(movements.isMoving)
        {
            ChangePattern(0);
        }
    }

    IEnumerator TimeBetwwenPattern()
    {
        ChangePattern(0);
        yield return new WaitForSeconds(pauseBetweenPatterns);
        isPause = false;
        if(currentPattern + 1 < patterns.Count)
        {
            currentPattern += 1;
        }
        else
        {
            currentPattern = 0;
        }
        currentTimer = 0.0f;
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

    public void ChangePattern(int pattern)
    {
        animator.SetInteger("Pattern", pattern);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "PlayerBullet")
        {
            WaveManager.instance.KillEnemy(this.gameObject);
            BulletManager.instance.DestroyBullet(collision.gameObject);
        }
    }
}
