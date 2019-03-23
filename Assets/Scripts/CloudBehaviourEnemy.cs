using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviourEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform[] Waypoints;
    //[SerializeField]
    //private GameObject _lightningbolt;
    //[SerializeField]
    //private Transform _lightningPosition;
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private float _jumpSpeed = 500;
    [SerializeField]
    private LayerMask _groundMask;
    //[SerializeField]
    //private GameObject _lightningBox;
    [SerializeField]
    private GameObject _lightningParticle;
    [SerializeField]
    private GameObject _hitbox;

    private int _index = 0;
    private SpriteRenderer _renderer;
    private float _timer;
    private bool _isShoot = false;
    

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        this.transform.position = Waypoints[_index].position;
        _lightningParticle.SetActive(false);
        _hitbox.SetActive(false);
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
           
        }else if (_timer > 7 && _timer <= 9)
        {
            _renderer.color = Color.Lerp(Color.gray, Color.black, 1);
            LightningStrike();

        }
        else if (_timer > 9)
        {
            _isShoot = false;
            _timer = 0;
            _lightningParticle.SetActive(false);
            _hitbox.SetActive(false);
        }
        else
        {
            _renderer.color = Color.Lerp(Color.black, Color.white, 1);
        }
    }

    private void FixedUpdate()
    {
        //LightningStrike();
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
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name);
        // put this in player
        if (col.tag == "Player")
        {
            col.GetComponent<Rigidbody2D>().AddForce(Vector3.up * _jumpSpeed);
            //this.enabled = false;
            //this.GetComponentInParent<GameObject>().SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    private void LightningStrike()
    {
        _lightningParticle.SetActive(true);
        _hitbox.SetActive(true);
    }
}
