using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance {  get; private set; }
    [HideInInspector] public List<GameObject> aliveEnnemies;
    [SerializeField] private PlayerShoot player;

    [Header("Spawn Positions")]
    public Transform spawnPositionOutOfScreen;
    public List<Transform> spawnPositionInGame;

    [Header("Parameters")]
    public float timeToGoFirstposition;
    public float timeBetweenWaves = 5.0f;

    [Header("Waves")]
    public List<EnemyWave> waves;
    private int actualWave = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        aliveEnnemies = new List<GameObject>();
        if(waves.Count > 0)
        {
            SpawnWave();
        }
    }



    private void SpawnWave()
    {
        foreach(Enemy enemy in waves[actualWave].ennemies)
        {
            GameObject enemyObject = Instantiate(enemy.prefab);
            enemyObject.transform.position = spawnPositionOutOfScreen.position;
            enemyObject.GetComponent<EnemyMovements>().MoveTo(spawnPositionInGame[enemy.sideSpawn].position);
            enemyObject.GetComponent<EnemyMovements>().actualPosition = enemy.sideSpawn;
            enemyObject.GetComponent<EnemyShoot>().patterns = enemy.patternList;
            aliveEnnemies.Add(enemyObject);
        }
    }

    public void KillEnemy(GameObject enemy)
    {
        aliveEnnemies.Remove(enemy);
        Destroy(enemy);

        if(aliveEnnemies.Count <= 0)
        {
            actualWave++;

            if (actualWave >= waves.Count)
                actualWave = 0;

            StartCoroutine(StartNextWave());
            player.StopShoot();
        }
    }

    IEnumerator StartNextWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        player.StartShoot();
        SpawnWave();
    }

    

}
