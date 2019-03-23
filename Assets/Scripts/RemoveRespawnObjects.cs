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
        if (!_ignorePlayer && other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().Health = 0;
        }
        // && _playerMask == (_playerMask | (1 << other.gameObject.layer)) breaks it
    }

}
