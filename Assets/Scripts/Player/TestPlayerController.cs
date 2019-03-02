using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    
    [SerializeField]
    private float _jumpForce = 1000f;
    [SerializeField]
    private float _maxSpeed = 3;

    private Rigidbody2D _rb;
    private float _move;
    

    private bool _facingLeft;
    
    
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
        
        if (Input.GetButtonDown("Jump")) Jump();

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
        // _rb.AddForce(new Vector2(0, _jumpForce));
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            this.transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            this.transform.SetParent(null);
        }
    }
}
