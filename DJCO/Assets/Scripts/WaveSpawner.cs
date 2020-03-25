using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING }

    [System.Serializable]
    public class EnemyUnit
    {
        public Transform unitPrefab;
        public int count;
        public float rate;
    }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public EnemyUnit[] units;
        public bool isMilestone = false;
    }

    public Wave[] waves;
    private int nextWave = 0;


    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    public GameObject ring;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;

    
    public float waveLoopingStage = 0f;
    
    public static WaveSpawner instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        waveCountdown = timeBetweenWaves;

    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        StartCoroutine(SpawnRings());


        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            waveLoopingStage++;
            Debug.Log("All waves complete! Looping...");
        }

        nextWave++;
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
                return false;
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name + " || " + _wave.units.Length);

        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.units.Length; i++)
        {
            StartCoroutine(SpawnEnemyUnit(_wave.units[i]));
            yield return new WaitForSeconds(0.5f);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    IEnumerator SpawnEnemyUnit(EnemyUnit unit)
    {
        
        for (int i = 0; i < unit.count; i++)
        {
            SpawnEnemy(unit.unitPrefab);
            yield return new WaitForSeconds(1f / unit.rate); ;
        }

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Vector3 vec = new Vector3(13, Random.Range(-6, 6), 0);
        Debug.Log("Spawning Enemy: " + _enemy.name);
        Instantiate(_enemy, vec, transform.rotation);
    }


    IEnumerator SpawnRings()
    {
        Vector3 vec = new Vector3(13, Random.Range(-6, 6), 0);
        Debug.Log("Spawning Rings");
        Instantiate(ring, vec, transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(ring, vec, transform.rotation);
        yield return new WaitForSeconds(0.3f); ;
        Instantiate(ring, vec, transform.rotation);
    }
}