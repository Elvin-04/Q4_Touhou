using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject bulletPlayerPrefab;
    public int initialBulletSpawn = 3000;
    public int initialBulletPlayerSpawn = 250;

    public static BulletManager instance { get; private set; }

    [SerializeField] private List<GameObject> AllBullets;

    private void Awake()
    {
        instance = this;
        AllBullets = new List<GameObject>();
    }

    void Start()
    {
        for (int i = 0; i < initialBulletSpawn; i++) 
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            AllBullets.Add(bullet);
        }

        for (int i = 0; i < initialBulletPlayerSpawn; i++)
        {
            GameObject bullet = Instantiate(bulletPlayerPrefab);
            bullet.SetActive(false);
            AllBullets.Add(bullet);
        }
    }

    public GameObject CreateBullet(string tag = "Bullet")
    {
        for (int i = 0; i < AllBullets.Count; i++)
        {
            if (AllBullets[i].tag == tag && !AllBullets[i].activeSelf)
            {
                AllBullets[i].SetActive(true);
                return AllBullets[i];
            }
        }

        if(tag == "PlayerBullet")
        {
            GameObject bulletPlayer = Instantiate(bulletPlayerPrefab);
            AllBullets.Add(bulletPlayer);
            return bulletPlayer;
        }

        GameObject bullet = Instantiate(bulletPrefab);
        AllBullets.Add(bullet);
        return bullet;
    }


    public void DestroyBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
