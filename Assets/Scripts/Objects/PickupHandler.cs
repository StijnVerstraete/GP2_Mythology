using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") PickupController.Pickup(gameObject.tag);
        Destroy(gameObject);
    }
}
