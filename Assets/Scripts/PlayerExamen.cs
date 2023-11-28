using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExamen : MonoBehaviour
{
    public float _jumpforce = 5;
    public float movement;
    public float velocity = 5;
    public Rigidbody2D _rbody;
    Animator _animator; 

    // Start is called before the first frame update
    void Awake()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
        if (Input.GetButtonDown("Jump") && GroundSensorExamen._isGrounded)
        {
            Jump();
        }
        _animator.SetBool("IsJumping+", !GroundSensorExamen._isGrounded);
        
    }

    void FixedUpdate()
    {
        _rbody.velocity = new Vector2 (movement * velocity, _rbody.velocity.y);
    }

    void Movement()
    {
        movement = Input.GetAxis("Horizontal");

        if(movement < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRunning+", true);
        }
        else if(movement > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRunning+", true);
        }
        else
        {
            _animator.SetBool("IsRunning+", false);
        }
    }
    void Jump()
    {
        _rbody.AddForce(Vector2.up * _jumpforce, ForceMode2D.Impulse);
    }
}
