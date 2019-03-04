using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    #region Fields
    
    //--- Private
    [SerializeField]
    float _jumpForce = 400f;

    Rigidbody2D _rb;
    float _move;
    float _maxSpeed = 5;
    
    bool _facingLeft, _grounded;
    float _groundRadius = .1f;

    //--- Public

    public Transform GroundCheck;
    public LayerMask GroundLayer;

    #endregion

    #region Properties

    public bool IsMoving { get => _move != 0; }

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponentInChildren<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _move = Input.GetAxis("Horizontal");

        if (_move > 0 && _facingLeft || _move < 0 && !_facingLeft) Flip();

        if (_grounded && Input.GetButtonDown("Jump")) Jump();

        if (Input.GetButtonDown("Action")) Action();

    }

    // Using FixedUpdate because physx
    private void FixedUpdate()
    {
        _grounded = Physics2D.OverlapCircle(GroundCheck.position, _groundRadius, GroundLayer);
        if (_grounded) _rb.velocity = new Vector2(_move * _maxSpeed, _rb.velocity.y);
    }

    private void Action()
    {
        Debug.Log("Player is using something");
    }

    private void Jump()
    {
       _rb.AddForce(new Vector2(0, _jumpForce));
    }

    // Flips the player to represent turning.
    private void Flip()
    {
        _facingLeft = !_facingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 11)
        {
            Debug.Log(_grounded);
            _grounded = true;
            this.transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == 11)
        {
            this.transform.SetParent(null);
        }
    }
    #endregion
}
