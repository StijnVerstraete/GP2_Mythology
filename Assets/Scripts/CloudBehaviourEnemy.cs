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

    private Animator _animator;

    private int _isAngryParam = Animator.StringToHash("IsAngry");


    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
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
        if ( _timer >= 5 && _timer <= 10)
        {
            _animator.SetBool(_isAngryParam, true);
            StartCoroutine(LightCoroutine(1));
        }
        else if(_timer >= 10)
        {
            _animator.SetBool(_isAngryParam, false);
            _isShoot = false;
            _timer = 0;
            _lightningParticle.SetActive(false);
            _hitbox.SetActive(false);
            StopAllCoroutines();
        }
    }
    
    IEnumerator LightCoroutine(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        LightningStrike();
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
