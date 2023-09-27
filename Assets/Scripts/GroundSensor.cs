using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool _isGrounded;
    public Animator _animator;

    void Start()
    { 
        _animator = GameObject.Find("mage").GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer ==  6)
        {
            _isGrounded = true;    
            _animator.SetBool("IsJumping", true);
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer ==  6)
        {
            _isGrounded = false; 
        }   
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer ==  6)
        {
            _isGrounded = true;
        }
    }
}
