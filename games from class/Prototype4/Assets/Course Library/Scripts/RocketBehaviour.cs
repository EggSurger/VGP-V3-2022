using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    public Transform target;
    private float speed = 45.0f;
    private bool homing;

    private float rocketStrength = 15.0f;
    private float aliveTimer = 5.0f;
    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update()
    {
        
if(homing )
{
    Vector3 moveDirection = (target.transform.position -
    transform.position).normalized;
    transform.position += moveDirection * speed * Time.deltaTime;
    transform.LookAt(target);
}

    }

    public void Fire(Transform newtarget)
   {
    target = newtarget;
    homing = true;
    Destroy(gameObject, aliveTimer);
   }
void OnCollisionEnter(Collision col)
   {
   if (target != null)
{
    if (col.gameObject.CompareTag(target.tag))
   {
   Rigidbody targetRigidbody = col.gameObject.GetComponent<Rigidbody>();
    Vector3 away = -col.contacts[0].normal;
    targetRigidbody.AddForce(away * rocketStrength, ForceMode.Impulse);
   Destroy(gameObject);
   }
   }
   }

}
