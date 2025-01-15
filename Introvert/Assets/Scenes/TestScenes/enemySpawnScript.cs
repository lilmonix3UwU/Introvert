using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnScript : MonoBehaviour
{
    //[SerializeField] GameObject[] enemyTypes; 
    public GameObject [] enemyPrefab;
    private int enemyCount;
    private int waveNumber = 1;

    public float timeBetweenEnemySpawn;
    public float timeBetweenWaves;

    public Transform[] spawnPoints;

    bool spawningWave;
    int enemiesToSpawn = 2; 

    void Start ()
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
            enemiesToSpawn++;
            Debug.Log("NY WAVE");
            StartCoroutine(SpawnEnemyWave(waveNumber));
        }
        
        

    }

    IEnumerator SpawnEnemyWave(int enemiesToSpawn = 2)
    {
        spawningWave = true;
        yield return new WaitForSeconds(timeBetweenWaves);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab[Random.Range(0,enemyPrefab.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)]);//, enemyPrefab.transform.rotation);
            yield return new WaitForSeconds(timeBetweenEnemySpawn);
        }
        spawningWave = false;
    }
}
