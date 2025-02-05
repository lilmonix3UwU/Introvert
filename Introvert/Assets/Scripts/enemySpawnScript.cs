using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemySpawnScript : MonoBehaviour
{
    //[SerializeField] GameObject[] enemyTypes; 
    public GameObject [] enemyPrefab;
    private int enemyCount;
    public int waveNumber = 1;

    public float timeBetweenEnemySpawn;
    public float timeBetweenWaves;

    public Transform[] spawnPoints;

    bool spawningWave;
    int enemiesToSpawn = 2; 
        
    void Start ()
    {
     StartCoroutine (SpawnEnemyWave(waveNumber));
     //Debug.Log("Vi laver et 2d top-down wave-shooter, der bruger et ottekantet gridsystem. Spillet handler om at overleve så lang tid som muligt mod fjender, som du skal skyde, da de vil røre dig.");
    }


    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0 && !spawningWave)
        {
            waveNumber++;
            enemiesToSpawn++;
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
        Debug.Log("Wave " + waveNumber);
    }
}
