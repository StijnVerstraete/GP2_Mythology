using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRespawnObjects : MonoBehaviour
{
    
    [SerializeField]
    private bool _ignorePlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //lightning bolt
        if (other.gameObject.layer == 12)
        {
            Destroy(other.gameObject);
        }

        //player
        if (other.gameObject.layer == 9 && !_ignorePlayer)
        {
            other.GetComponent<TestPlayerController>().Health = 0;
        }
        
    }

}
