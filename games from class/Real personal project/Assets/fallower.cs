using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallower : MonoBehaviour
{
      public float speed = 600;
     public Rigidbody enemyRb;
     public GameObject playerGoal;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("p");

    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);


    }

    
        

    
}
