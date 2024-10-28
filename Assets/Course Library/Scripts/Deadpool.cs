using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadpool : MonoBehaviour
{

    public float speed;
    private Rigidbody DeadpoolRb;
    private GameObject Wolverine;
    public int DeadpoolCount;

    // Start is called before the first frame update
    void Start()
    {
        DeadpoolRb = GetComponent<Rigidbody>();
        Wolverine = GameObject.Find("Wolverine");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
          Destroy(gameObject); 
        }
        Vector3 lookDirection = (Wolverine.transform.position - transform.position).normalized;
        DeadpoolRb.AddForce(lookDirection * speed); 
    }
}