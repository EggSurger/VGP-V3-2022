using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private float leftBound = -15;
    private PlayerControler playerControlerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControlerScript = GameObject.Find("Player").GetComponent<PlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControlerScript.gameOver == false){
       transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")){
            Destroy(gameObject);
        }
       } 
    }
}
