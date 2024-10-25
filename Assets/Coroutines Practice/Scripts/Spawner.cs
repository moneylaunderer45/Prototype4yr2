using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject CannonBallPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.S))
      {
        Instantiate(CannonBallPrefab, new Vector3(0, 0, 6), CannonBallPrefab.transform.rotation);
      }
    }
}