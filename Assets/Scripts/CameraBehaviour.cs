using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = this.transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        this.transform.position = _player.transform.position + _offset;
    }
}
