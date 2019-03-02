using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRespawnObjects : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        //lightning bolt
        if (other.gameObject.layer == 12)
        {
            Destroy(other.gameObject);
        }
    }

}
