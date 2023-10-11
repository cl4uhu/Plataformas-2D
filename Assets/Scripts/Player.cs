using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header ("Player Stats")]
    [Tooltip("Controla la velocidad de movimiento del personaje")]
    [SerializeField]private float _playerSpeed = 5;
    [Tooltip("Controla la fuerza de salto del personaje")]
    [SerializeField]private float _jumpForce = 5;
    private float _playerInputHorizontal; 
    //private float _playerInputVertical;

    private Rigidbody2D _rBody2D;
    //private GroundSensor _sensor;
    [SerializeField] public Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
      _rBody2D = GetComponent<Rigidbody2D>();
      //_sensor = GetComponentInChildren<GroundSensor>();
    }

    void FixedUpdate()
    {
      //_rBody2D.AddForce(new Vector2(_playerInputHorizontal *_playerSpeed, 0), ForceMode2D.Impulse);
      _rBody2D.velocity = new Vector2(_playerInputHorizontal * _playerSpeed, _rBody2D.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement ();  

        if(Input.GetButtonDown("Jump") && GroundSensor._isGrounded)
        {
          Jump();
          _animator.SetBool("IsJumping", true);
        }
    }

    void PlayerMovement()
    { 
      _playerInputHorizontal = Input.GetAxis("Horizontal");
      /*_playerInputVertical = Input.GetAxis("Vertical");
        
      transform.Translate(new Vector2(_playerInputHorizontal, _playerInputVertical) * _playerSpeed * Time.deltaTime);*/ 
      
      if(_playerInputHorizontal < 0)
      {
          transform.rotation = Quaternion.Euler(0, 180, 0);
          _animator.SetBool("IsRunning", true);
      }

      else if(_playerInputHorizontal > 0)
      {
          transform.rotation = Quaternion.Euler(0, 0, 0);
          _animator.SetBool("IsRunning", true);
      }
      
      else
      {
         _animator.SetBool("IsRunning", false);
      }
    }

    void Jump ()
    {
      _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
