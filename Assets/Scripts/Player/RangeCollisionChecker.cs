using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCollisionChecker : MonoBehaviour
{
    [SerializeField]
    private LayerMask _mask;

    private bool _isSomethingChecked;

    public bool IsSomethingChecked
    {
        get { return _isSomethingChecked; }
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    _collisionMask = collision.gameObject.layer;
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_mask == (_mask | (1 << collision.gameObject.layer)))
        {
            _isSomethingChecked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_mask == (_mask | (1 << collision.gameObject.layer)))
        {
            _isSomethingChecked = false;
        }
    }
}
