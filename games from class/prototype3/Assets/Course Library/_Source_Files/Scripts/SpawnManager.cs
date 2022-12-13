using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ObstacleList;
    public GameObject obstaclePrefab;
    public GameObject obstaclePrefab2;
    private Vector3 spawnpos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerControler playerControllerScript;
    private float leftBound =-10;
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")){
            Destroy(gameObject);
        }

    }



    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false){
        Instantiate(ObstacleList[Random.Range(obstaclePrefab,obstaclePrefab2)], spawnpos, obstaclePrefab.transform.rotation);
        }
    }
}
