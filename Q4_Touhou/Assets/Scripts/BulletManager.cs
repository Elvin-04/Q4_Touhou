using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject bulletPlayerPrefab;

    public List<GameObject> differentBulletType = new List<GameObject>();

    public int BulletSpawnByType = 300;

    public static BulletManager instance { get; private set; }

    [SerializeField] private List<GameObject> AllBullets;

    private void Awake()
    {
        instance = this;
        AllBullets = new List<GameObject>();
    }

    void Start()
    {

        for (int i = 0; i < differentBulletType.Count; i++)
        {
            for (int j = 0; j < BulletSpawnByType; j++)
            {
                GameObject bullet = Instantiate(differentBulletType[i]);
                bullet.SetActive(false);
                AllBullets.Add(bullet);
            }
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


        foreach(GameObject type in differentBulletType)
        {
            if(type.tag == tag)
            {
                GameObject bulletToCreate = Instantiate(type);
                AllBullets.Add(bulletToCreate);
                return bulletToCreate;
            }
        }


        Debug.LogError("Bullet tag does not exist");
        return null;
    }


    public void DestroyBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
