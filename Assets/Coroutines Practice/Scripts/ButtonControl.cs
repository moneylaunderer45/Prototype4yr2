using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{

    public bool isPushed = false;

    private void OnCollisionEnter(Collision collision)
    {
      if (!isPushed)
      {
        isPushed = true; 
        Debug.Log("Boop! You pushed button! ");
        StartCoroutine(ButtonReset());
      }
    }


    IEnumerator ButtonReset()
    {
      yield return new WaitForSeconds(5);
      isPushed = false; 
    }
}