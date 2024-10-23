using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleControl : MonoBehaviour
{
    //VARIABLES

    [Header("Movement")]
    public float moveSpeed;
    public float turnSpeed;
    public float jumpForce;
    public bool isOnGround = true;
    private float verticalInput;
    private float horizontalInput;
    private Rigidbody playerRb;

    [Header("Shooting")]
    public GameObject projectile;
    public float shootDelay;
    public GameObject spawnPoint;
    private bool canShoot = true; 


    // Start is called before the first frame update
    void Start()
    {
       playerRb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Forward and Backward Movement
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * verticalInput * Time.deltaTime * moveSpeed);
       
        //Clockwise and counterclockwise Rotation
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);


        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
          isOnGround = false;
          playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }

        //Shooting
        if(Input.GetKeyDown(KeyCode.Q) && canShoot)
        {
          canShoot = false; 
          Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
          StartCoroutine(ShootDelay());
        }
    }

    //Make a corountine to delay shooting
    IEnumerator ShootDelay()
    {
     yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}