using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    private int _health;

    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }
    
    [SerializeField]
    private float _jumpForce = 1000f;
    [SerializeField]
    private float _maxSpeed = 3;
    [SerializeField]
    private GroundCheck _ground;
    [SerializeField]
    private LayerMask _lightningMask;
    [SerializeField]
    private LayerMask _platformMask;
    [SerializeField]
    private LayerMask _enemyMask;

    private Rigidbody2D _rb;
    private float _move;
    private bool _grounded;

    private bool _facingLeft;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponentInChildren<Rigidbody2D>();
        _health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Ground " + _ground.IsGrounded);
        _move = Input.GetAxis("Horizontal");

        if (_move > 0 && _facingLeft || _move < 0 && !_facingLeft) Flip();

        if (_ground.IsGrounded && Input.GetButtonDown("Jump")) { Jump(); }


        if (!_ground.IsGrounded)
        {
            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else
        {
            this.GetComponent<BoxCollider2D>().isTrigger = false;
        }
            

        if (Input.GetButtonDown("Action")) Action();

    }

    // Using FixedUpdate because physx
    private void FixedUpdate()
    {
         _rb.velocity = new Vector2(_move * _maxSpeed, _rb.velocity.y);
    }

    private void Action()
    {
        Debug.Log("Player is using something");
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpForce);
    }

    // Flips the player to represent turning.
    private void Flip()
    {
        _facingLeft = !_facingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_lightningMask == (_lightningMask | (1 << other.gameObject.layer)))
        {
            _health--;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_platformMask == (_platformMask | (1 << collision.gameObject.layer)))
        {
            this.transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (_platformMask == (_platformMask | (1 << collision.gameObject.layer)))
        {
            this.transform.SetParent(null);
        }
    }
}
