using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitWaterAnimationBehaviour : MonoBehaviour
{
    [SerializeField]
    private int _secondsTeller = 5;
    [SerializeField]
    private Animation _animation;

    private float _timer;
    

    // Start is called before the first frame update
    void Start()
    {
        //_animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _secondsTeller)
        {
            _animation.Play();
            _timer = 0;
        }
    }
}
