using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if collision with player
        if (collision.gameObject.tag == "Player") HandleDialog();
    }

    void HandleDialog()
    {
        PickupController.Pickup(gameObject.tag);
    }

}
