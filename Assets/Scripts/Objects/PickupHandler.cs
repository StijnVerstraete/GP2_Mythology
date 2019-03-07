using UnityEngine;

public class PickupHandler : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if collision with player
        if (collision.gameObject.tag == "Player") HandlePickup();
    }

    void HandlePickup()
    {
        PickupController.Pickup(gameObject.tag);
        Destroy(gameObject);
    }
}
