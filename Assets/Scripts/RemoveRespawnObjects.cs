using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRespawnObjects : MonoBehaviour
{
    [SerializeField]
    private bool _ignorePlayer;

    [SerializeField]
    private LayerMask _lightningMask;
    [SerializeField]
    private LayerMask _playerMask;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //lightning bolt
        if (_lightningMask == (_lightningMask | (1 << other.gameObject.layer)))
        {
            Destroy(other.gameObject);
        }

        //player
        if (!_ignorePlayer && _playerMask == (_playerMask | (1 << other.gameObject.layer)) && other.tag == "Player")
        {
            other.gameObject.GetComponent<TestPlayerController>().Health = 0;
        }

    }

}
