using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviourEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _lightningbolt;
    [SerializeField]
    private Transform _lightningPosition;

    private SpriteRenderer _renderer;
    private float _timer;
    private bool _isShoot = false;
    

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        //todo color lerp
        // shaking

        

        if (_timer >= 3 && _timer <= 7)
        {
            _renderer.color = Color.Lerp(Color.white, Color.gray, 1);
           
        }else if (_timer > 7 && _timer <= 10)
        {
            _renderer.color = Color.Lerp(Color.gray, Color.black, 1);
            ShootLightningbolt();

        }
        else if (_timer > 10)
        {
            _isShoot = false;
            _timer = 0;
        }
        else
        {
            _renderer.color = Color.Lerp(Color.black, Color.white, 1);
        }
        
    }

    private void ShootLightningbolt()
    {
        if (!_isShoot)
        {
            Instantiate(_lightningbolt, _lightningPosition.position, _lightningPosition.rotation);
            _isShoot = true;
        }
        

    }
}
