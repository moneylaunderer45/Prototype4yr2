using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolverineController : MonoBehaviour
{
    private Rigidbody WolverineRb;
    public float speed = 5.0f;
    private GameObject focalPoint;
    public bool hasPowerup;
    private float powerupStrength = 15f;
    public GameObject powerupIndicator; 

    // Start is called before the first frame update
    void Start()
    {
        WolverineRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
      float forwardInput = Input.GetAxis("Vertical");
      WolverineRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0); 
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.CompareTag("Power Up"))
      {
        hasPowerup = true;
        Destroy(other.gameObject);
        StartCoroutine(PowerupCountdownRoutine()); 
      }
    }

    IEnumerator PowerupCountdownRoutine()
    {
      powerupIndicator.gameObject.SetActive(false); 
      
      yield return new WaitForSeconds(7);
      hasPowerup = false; 
    }

    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("Enemy"))
      {
        powerupIndicator.gameObject.SetActive(true);

        Rigidbody DeadpoolRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromWolverine = (collision.gameObject.transform.position - transform.position);

        Debug.Log("Collided with" + collision.gameObject.name + "with powerup set to" + hasPowerup);
        DeadpoolRigidbody.AddForce(awayFromWolverine * powerupStrength, ForceMode.Impulse); 
      }
    }
}