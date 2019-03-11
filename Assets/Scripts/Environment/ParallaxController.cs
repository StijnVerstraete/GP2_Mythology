using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
            if (_charCont.IsMoving) ApplyParallax(i);
            else if (ShowFloat[i]) ApplyParallax(i);
        }
    }

    void ApplyParallax(int i)
    {
        if (ParallaxLayers[i].transform.position.x < -35) ParallaxLayers[i].transform.position = new Vector3(0, ParallaxLayers[i].transform.position.y, 0);
        ParallaxLayers[i].transform.Translate(Vector3.left * Time.deltaTime * ((ParallaxSpeeds[i] > 0) ? ParallaxSpeeds[i] : _accelerationRate));
    }

    #endregion
}
