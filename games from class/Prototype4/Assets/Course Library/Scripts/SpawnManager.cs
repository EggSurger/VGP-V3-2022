using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int enemyCount;
    public GameObject[] EnemeyPrefab;
    private float spawnRange = 9;
    public int waveNumber = 1;
    public GameObject[] powerupPrefabs;
    
    // Start is called before the first frame update
    void Start()
    {{
       
        SpawnEnemyWave(waveNumber);}
    }
    void Update()
    {
    enemyCount = FindObjectsOfType<Enemy>().Length;
    if (enemyCount == 0)
    {
        waveNumber++;
        SpawnEnemyWave(waveNumber);
       
    }
    
     
    }
    private void SpawnEnemyWave(int enemiesToSpawn){
        
        for(int i = 0; i < enemiesToSpawn; i++){
            int randomEnemy = Random.Range(0,EnemeyPrefab.Length);
            Instantiate(EnemeyPrefab[randomEnemy], GenerateSpawnPosition(), EnemeyPrefab[randomEnemy].transform.rotation);
 
             Instantiate(powerupPrefabs.Length);
             int randomPowerup = Random.Range(0,powerupPrefabs[randomPowerup], GenerateSpawnPosition(),
             powerupPrefabs[randomPowerup].transform.rotation);
        }
    }
    
    // Update is called once per frame
   
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    }
