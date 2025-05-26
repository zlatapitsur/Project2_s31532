using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;


    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true; 
    }

    // Update is called once per frame
    //void Update()
    private void OnCollisionExit2D(Collision2D collision)
    {
       isGrounded = false;
    }
}

