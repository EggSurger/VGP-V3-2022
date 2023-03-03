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
    {
        int randomPowerup = Random.Range(0, powerupPrefabs.Length);
Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(),
powerupPrefabs[randomPowerup].transform.rotation);
        SpawnEnemyWave(waveNumber);
    }
    void SpawnEnemyWave(int enemiesToSpawn){
        
        for(int i = 0; i < enemiesToSpawn; i++){
            int randomEnemy = Random.Range(0,EnemeyPrefab.Length);
            Instantiate(EnemeyPrefab[randomEnemy], GenerateSpawnPosition(), EnemeyPrefab[randomEnemy].transform.rotation);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
         {
            waveNumber ++;
            SpawnEnemyWave(waveNumber);
            int randomPowerup = Random.Range(0, powerupPrefabs.Length);
Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(),
powerupPrefabs[randomPowerup].transform.rotation);

         }
    }
    private Vector3 GenerateSpawnPosition(){
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
