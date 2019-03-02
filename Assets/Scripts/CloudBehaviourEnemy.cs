using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviourEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform[] Waypoints;
    [SerializeField]
    private GameObject _lightningbolt;
    [SerializeField]
    private Transform _lightningPosition;
    [SerializeField]
    private float _speed = 1;

    private int _index = 0;
    private SpriteRenderer _renderer;
    private float _timer;
    private bool _isShoot = false;
    

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        this.transform.position = Waypoints[_index].position;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        MoveCloudBetweenWaypoints();

        //todo
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

    private void MoveCloudBetweenWaypoints()
    {
        if (Vector3.Distance(transform.position, Waypoints[_index].position) <= _speed * Time.deltaTime)
        {
            ++_index;
            _index %= Waypoints.Length;
        }

        this.transform.position = Vector3.MoveTowards(transform.position, Waypoints[_index].transform.position, _speed * Time.deltaTime);
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
