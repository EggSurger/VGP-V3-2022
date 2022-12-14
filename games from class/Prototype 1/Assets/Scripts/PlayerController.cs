using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // variabols
    private float speed = 10.0f;
    private float turnspeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //user input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        
        //rotates vehical
        transform.Rotate(Vector3.up, turnspeed * horizontalInput * Time.deltaTime);

    }
}
