using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTriggerBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //if the thunder is hitting the player the health goes down with 1
        {
            collision.GetComponent<PlayerController>().TakeDamage();
        }
    }
}
