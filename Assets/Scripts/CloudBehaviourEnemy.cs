using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviourEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform[] Waypoints;
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private float _jumpSpeed = 2000;
    //[SerializeField]
    //private LayerMask _groundMask;
    [SerializeField]
    private GameObject _lightningParticle;
    [SerializeField]
    private GameObject _hitbox;
    [SerializeField]
    private Sprite[] _cloudImages;

    private int _index = 0;
    private SpriteRenderer _renderer;
    private float _timer;
    private bool _isShoot = false;
    private bool _isPlayerHitCloud = false;

    private float _squish;
    [SerializeField]
    private Transform _sprite;
    private int _squishFrame = 0;
    private Vector3 _startScale;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        this.transform.position = Waypoints[_index].position;
        _lightningParticle.SetActive(false);
        _hitbox.SetActive(false);

        _startScale = _sprite.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPlayerHitCloud)
        {
            _timer += Time.deltaTime;

            MoveCloudBetweenWaypoints();

            ChangeCloudSprite();
        }

        //squish
        _sprite.localScale = _startScale + new Vector3(0, _squish * Mathf.Sin(_squishFrame * 0.3f));
        _squishFrame++;
        _squish = Mathf.Lerp(_squish, 0, 0.1f);
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

    private void ChangeCloudSprite()
    {
        //todo
        // shaking
        if (_timer >= 3 && _timer <= 5)
        {
            //_renderer.color = Color.Lerp(Color.white, Color.gray, 1);
            _renderer.sprite = _cloudImages[1];
        }
        else if (_timer > 5 && _timer <= 7)
        {
            //_renderer.color = Color.Lerp(Color.gray, Color.black, 1);
            _renderer.sprite = _cloudImages[2];
            LightningStrike();

        }
        else if (_timer > 7)
        {
            _isShoot = false;
            _timer = 0;
            _lightningParticle.SetActive(false);
            _hitbox.SetActive(false);
        }
        else if (!_isPlayerHitCloud)
        {
            //_renderer.color = Color.Lerp(Color.black, Color.white, 1);
            _renderer.sprite = _cloudImages[0];
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name);
        //Debug.Log(col.gameObject.tag);
        // put this in player
        //if (col.gameObject.tag == "Player")
        //{
        //    _isPlayerHitCloud = true;
        //    col.GetComponent<Rigidbody2D>().AddForce(Vector3.up * _jumpSpeed);
        //    //this.enabled = false;
        //    //this.GetComponentInParent<GameObject>().SetActive(false);
        //    //_renderer.sprite = _cloudImages[3];
        //    this.gameObject.SetActive(false);
        //}
    }

    private void LightningStrike()
    {
        _lightningParticle.SetActive(true);
        _hitbox.SetActive(true);
    }

    public void CloudDie()
    {
       this.gameObject.SetActive(false);
    }

    public void CloudSQuash()
    {
        _squish = .6f;
        _squishFrame = 0;
    }
}
