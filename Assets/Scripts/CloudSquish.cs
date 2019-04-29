using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSquish : MonoBehaviour
{
    private float _squish;
    [SerializeField]
    private Transform _sprite;
    private int _squishFrame = 0;
    private Vector3 _startScale;

    // Start is called before the first frame update
    void Start()
    {
        _startScale = _sprite.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //squish
        _sprite.localScale = _startScale + new Vector3(0, _squish * Mathf.Sin(_squishFrame * 0.3f));
        _squishFrame++;
        _squish = Mathf.Lerp(_squish, 0, 0.1f);
    }

    public void CloudSQuash()
    {
        _squish = .6f;
        _squishFrame = 0;
    }
}
