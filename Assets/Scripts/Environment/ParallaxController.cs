using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{

    #region Fields

    //--- Private
    float _accelerationRate = .5f;
    PlayerController _charCont;

    //--- Public
    public GameObject[] ParallaxLayers;
    public LayerMask BackgroundLayer;
    [HideInInspector]
    public List<bool> ShowFloat = new List<bool>();
    [HideInInspector]
    public List<float> ParallaxSpeeds = new List<float>();

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        _charCont = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        // Add second background for each existing one.
        foreach (GameObject background in ParallaxLayers)
        {
            GameObject _newObj = Instantiate(background, background.transform);
            _newObj.transform.position = background.transform.position + new Vector3(35, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ParallaxLayers.Length > 0) ProcessBackgroundLayers();
    }

    void ProcessBackgroundLayers()
    {
        for (int i = 0; i < ParallaxLayers.Length; i++)
        {
            // We check for the layers that are independent of player movement first, then we check if the player is moving.
            if (ShowFloat[i]) ApplyParallax(i, true);
            else if (_charCont.IsMoving) ApplyParallax(i, false);
        }
    }

    void ApplyParallax(int i, bool _ignorePlayerMovement)
    {
        // Check if one of the layers exiths the boundaries, if so, reset it.
        BackgroundOutOfBoundsCheck(i);

        // Added bit to make sure parallax moves in the players' direction, but ignore if layer independent of player movement.
        Vector3 _direction = (_ignorePlayerMovement) ? Vector3.right : (_charCont.MovementDirection == "left") ? Vector3.left : Vector3.right;

        // Apply the movement
        ParallaxLayers[i].transform.Translate(_direction * Time.deltaTime * ((ParallaxSpeeds[i] > 0) ? ParallaxSpeeds[i] : _accelerationRate));
    }

    void BackgroundOutOfBoundsCheck(int i)
    {
        Vector3 _size = ParallaxLayers[i].GetComponent<Renderer>().bounds.size;
        float _xPosition = ParallaxLayers[i].transform.position.x;

        // Check if exited left or right in that order. If so, reset.
        if (_xPosition < -_size.x || _xPosition > _size.x) ResetBackgroundPosition(i, _size, (_xPosition < -_size.x));
    }

    void ResetBackgroundPosition(int i, Vector3 _size, bool _exitLeft)
    {
        //Debug.Log(string.Format("Reset layer {0} and exited {1}", i, (_exitLeft ? "left" : "right")));
        float _xPosition = _exitLeft ? _size.x: -_size.x;
        ParallaxLayers[i].transform.position = new Vector3(_xPosition, ParallaxLayers[i].transform.position.y, 0);
    }

    #endregion
}
