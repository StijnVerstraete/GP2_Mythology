using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private GameObject _player;
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        // Find player first, then try and do thing with it...
        _player = GameObject.FindGameObjectWithTag("Player");

        _offset = transform.position - _player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = Vector3.MoveTowards(_player.transform.position + _offset,transform.position,0.2f);
    }
}
