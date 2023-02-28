using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    public float speed = 10.0f;
    public float speedRot = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!target) {Destroy(gameObject); return;}

        Vector3 lookDirection = target.transform.position - transform.position;

        Quaternion rotateTarget = Quaternion.LookRotation(lookDirection, Vector3.up) * Quaternion.Euler(90.0f, 0, 0);
        Quaternion rotate = Quaternion.RotateTowards(transform.rotation, rotateTarget,speedRot);

        transform.rotation = rotate;

        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform. position;

            enemyRigidbody.AddForce(awayFromPlayer * 10.0f, ForceMode.Impulse);
        }
        else if(!collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
