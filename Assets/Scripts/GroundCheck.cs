using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private LayerMask _mask;

    private bool _isGrounded;

    public bool IsGrounded
    {
        get { return _isGrounded; }
        set { _isGrounded = value; }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_mask == (_mask | (1 << col.gameObject.layer)))
        {
            _isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (_mask == (_mask | (1 << col.gameObject.layer)))
        {
            _isGrounded = false;
        }
          
    }
}
