﻿using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    #region Fields
    
    //--- Public
    public GroundCheck Ground;
    public LayerMask LightningMask, PlatformMask, EnemyMask;
    public bool IsHandlingUI;

    [SerializeField]
    float _jumpForce = 1000f;
    [SerializeField]
    float _maxSpeed = 3;

    //--- Private
    //float _jumpForce = 1000f;
    //float _maxSpeed = 3;
    Rigidbody2D _rb;
    float _move;
    bool _grounded;
    bool _facingLeft;
    Collider2D _boxcollider;

    private bool _isMoveablePlatformAboveHead;

    #endregion

    #region Properties

    public int Health { get; set; } = 3;

    // Needed for character controller, please do NOT delete this time...
    public bool IsMoving { get => _move != 0; }

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponentInChildren<Rigidbody2D>();
        _boxcollider = GetComponentInChildren<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsHandlingUI) ProcessInput();
        else if (_move != 0) _move = 0;
    }

    private void ProcessInput()
    {
        //Debug.Log("Ground " + Ground.IsGrounded);
        _move = Input.GetAxis("Horizontal");

        if (_move > 0 && _facingLeft || _move < 0 && !_facingLeft) Flip();

        if (Ground.IsGrounded && Input.GetButtonDown("Jump")) { Jump(); }

        _boxcollider.isTrigger = (!Ground.IsGrounded && _isMoveablePlatformAboveHead);

        if (Input.GetButtonDown("Action")) Action();
    }

    // Using FixedUpdate because physx
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_move * _maxSpeed, _rb.velocity.y);

        IsSomethingAboutMyHead();
    }

    void Action()
    {
        //Debug.Log("Player is using something");
    }

    void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpForce);
    }

    // Flips the player to represent turning.
    void Flip()
    {
        _facingLeft = !_facingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //why trigger this 2 times????
        //if (LightningMask == (LightningMask | (1 << other.gameObject.layer))) Health--;

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (IsPlatform(collision)) transform.SetParent(collision.transform);

        if (PlatformMask == (PlatformMask | (1 << collision.gameObject.layer)))
        {
            this.transform.SetParent(collision.transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
       // if (IsPlatform(collision)) transform.SetParent(null);

        if (PlatformMask == (PlatformMask | (1 << collision.gameObject.layer)))
        {
            this.transform.SetParent(null);
        }
    }

    bool IsPlatform(Collision2D _c)
    {
        return (PlatformMask == (PlatformMask | (1 << _c.gameObject.layer)));
    }


    private void IsSomethingAboutMyHead()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity, PlatformMask);
        Debug.DrawRay(transform.position, hit.point, Color.green);

        if (hit.collider != null)
        {
            _isMoveablePlatformAboveHead = true;
        }
        else
        {
            _isMoveablePlatformAboveHead = false;
        }
    }




    #endregion

}
