using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Fields

    //--- Private
    GameObject _player;
    Camera _camera;
    Vector3 _offset;

    //--- Public
    public GameObject[] CameraBorders;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        // Find main camera in scene
        _camera = Camera.main;

        // Find player first, then try and do thing with it...
        _player = GameObject.FindGameObjectWithTag("Player");


        // Set camera position to a fixed constant every time.
        Vector3 _relativePlayerPos = _player.transform.position;
        _relativePlayerPos.y += 2;
        _relativePlayerPos.z = -5;
        _camera.transform.position = _relativePlayerPos;

        // Save position offset.
        _offset = transform.position - _player.transform.position;
    }

    void Update()
    {
        if (CinematicMode.Initialized) CinematicMode.HandleBlend();
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = Vector3.MoveTowards(_player.transform.position + _offset,transform.position,0.2f);
    }

    #endregion
}
