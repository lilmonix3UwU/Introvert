using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    int enemiesToSpawn;
    [SerializeField] private TextMeshProUGUI waveCounter;
        
    void Awake ()
    {
        Debug.Log("JEG ER VÅGEN");
        enemiesToSpawn = 2;
     StartCoroutine (SpawnEnemyWave(enemiesToSpawn));
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
            StartCoroutine(SpawnEnemyWave(enemiesToSpawn));
        }
        

    }
    IEnumerator SpawnEnemyWave(int enemiesToSpawn)
    {
        spawningWave = true;
        waveCounter.text = "Wave " + waveNumber;
        Debug.Log("Wave " + waveNumber);
        waveCounter.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeBetweenWaves);
        waveCounter.gameObject.SetActive(false);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab[Random.Range(0,enemyPrefab.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)]);//, enemyPrefab.transform.rotation);
            yield return new WaitForSeconds(timeBetweenEnemySpawn);
        }
        spawningWave = false;
        
    }
}
