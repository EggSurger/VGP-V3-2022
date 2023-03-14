using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
   //public GameObject target;
    //public float speed = 10.0f;
   // public float speedRot = 10.0f;
private Transform target;
private float speed = 15.0f;
private bool homing = true;

private float rocketStrength = 15.0f;
private float aliveTimer = 5.0f;
    // Start is called before the first frame update
    void Start(){
    
    }

    // Update is called once per frame
    void Update()
    {
        /*
         if (!target) { Destroy(gameObject);}
; 
          Vector3 lookDirection = target.transform.position - transform.position;

        Quaternion rotateTarget = Quaternion.LookRotation(lookDirection, Vector3.up) * Quaternion.Euler(90.0f, 0, 0);
        Quaternion rotate = Quaternion.RotateTowards(transform.rotation, rotateTarget, speedRot);

        transform.rotation = rotate;


        transform.Translate(Vector3.up * Time.deltaTime * speed);
        */
if (homing && target !=null)
{
    Vector3 moveDirection = (target.transform.position - transform.position) .normalized;
    transform.position += moveDirection * speed * Time.deltaTime;
    transform.LookAt (target);
}
    }
 public void Fire(Transform newTarget)
{
    target = newTarget;
    homing = true;
    Destroy(gameObject, aliveTimer);
}


    

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
           Rigidbody targetRigidbody = collision.gameObject.GetComponent<Rigidbody>();
           Vector3 away = -collision.contacts[0].normal;
           targetRigidbody.AddForce(away * rocketStrength, ForceMode.Impulse);
           Destroy(gameObject);
        }
    }
}
