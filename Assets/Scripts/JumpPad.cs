using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    
    public Rigidbody2D bouncer;
    public float jumpForce = 20f;
    
    private void OnCollisionEnter2D(Collision2D other) {
        
        bouncer = other.gameObject.GetComponent<Rigidbody2D>();
        bouncer.velocity = transform.up * jumpForce;

    }

}