using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerControler PlayerControlerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControlerScript.gameOver == false){
       transform.Translate(Vector3.left * Time.deltaTime * speed);
       } 
    }
}
