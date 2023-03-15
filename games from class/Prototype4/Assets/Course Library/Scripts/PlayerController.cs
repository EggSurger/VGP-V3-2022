using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject Bullet;
    public float speed = 5.0f;
    public bool hasPowerup;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;
    public PowerUpType currentPowerUp = PowerUpType.None;
    public GameObject rocketPrefab;
    private GameObject tmpRocket;
    private Coroutine powerupCountdown;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (currentPowerUp == PowerUpType.Rockets && Input.GetKeyDown(KeyCode.F))
{

}
    }
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("PowerUp")){
            hasPowerup = true;
            currentPowerUp = other.gameObject.GetComponent<PowerUp>().powerUpType;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
           if(powerupCountdown != null)
           {
            StopCoroutine(powerupCountdown);
           }
           powerupCountdown = StartCoroutine(PowerupCountdownRoutine());
        }
        IEnumerator PowerupCountdownRoutine(){
            yield return new WaitForSeconds(7);
            hasPowerup = false;
            currentPowerUp = PowerUpType.None;
            powerupIndicator.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && currentPowerUp == PowerUpType.Pushback)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
        Debug.Log("Collided with" + collision.gameObject.name + "with powerup set to" + hasPowerup);
        
        enemyRigidbody.AddForce(awayFromPlayer * powerupStrength,ForceMode.Impulse);

        }

    }
void LaunchRockets()
{
    foreach(var enemy in FindObjectsOfType<Enemy>())
    {
        tmpRocket = Instantiate(rocketPrefab, transform.position + Vector3.up, Quaternion.identity);
        tmpRocket.GetComponent<RocketBehaviour>().Fire(enemy.transform);
    }
}
   
}
