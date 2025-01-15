using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnScript : MonoBehaviour
{
    [SerializeField] GameObject[] enemyTypes; 
    public GameObject enemyPrefab;
    private int enemyCount;
    private int waveNumber = 1;

    public float timeBetweenEnemySpawn;
    public float timeBetweenWaves;

    public Transform[] spawnPoints;

    bool spawningWave;

    private void Awake()
    {
        StartCoroutine (SpawnEnemyWave(waveNumber));
    }


    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0 && !spawningWave)
        {
            waveNumber++;
            Debug.Log("NY WAVE");
            StartCoroutine(SpawnEnemyWave(waveNumber));
        }
        
        

    }

    IEnumerator SpawnEnemyWave(int enemiesToSpawn)
    {
        spawningWave = true;
        yield return new WaitForSeconds(timeBetweenWaves);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate (enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, enemyPrefab.transform.rotation);
            yield return new WaitForSeconds(timeBetweenEnemySpawn);
        }
        spawningWave = false;
    }
}
