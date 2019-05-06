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
    [SerializeField]
    private SpriteGlow.SpriteGlowEffect _glow;
    

    private int _index = 0;
    private SpriteRenderer _renderer;
    private float _timer;
    private bool _isShoot = false;
    private bool _isPlayerHitCloud = false;

    //private float _squish;
    //[SerializeField]
    //private Transform _sprite;
    //private int _squishFrame = 0;
    //private Vector3 _startScale;

    private Animator _animator;

    private int _isDeadParam = Animator.StringToHash("IsDead");


    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        this.transform.position = Waypoints[_index].position;
        //_lightningParticle.SetActive(false);
        //_hitbox.SetActive(false);
        SetActiveState(false);
        _glow = this.GetComponent<SpriteGlow.SpriteGlowEffect>();

        _glow.enabled = false;

        //_startScale = _sprite.localScale;
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
        else
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            SetActiveState(false);
        }

        ////squish
        //_sprite.localScale = _startScale + new Vector3(0, _squish * Mathf.Sin(_squishFrame * 0.3f));
        //_squishFrame++;
        //_squish = Mathf.Lerp(_squish, 0, 0.1f);
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
        if (_timer >= 4 && _timer < 5)
        {
            _glow.enabled = true;
        }else
        if ( _timer >= 5 && _timer <= 8)
        {
            _glow.enabled = false;
            //_animator.SetBool(_isAngryParam, true);
            //StartCoroutine(LightCoroutine(1));
            LightningStrike();
        }
        else if(_timer >= 8)
        {
            //_animator.SetBool(_isAngryParam, false);
            _isShoot = false;
            _timer = 0;
            //_lightningParticle.SetActive(false);
            //_hitbox.SetActive(false);
            //StopAllCoroutines();

            SetActiveState(false);
        }
    }
    
    //IEnumerator LightCoroutine(int seconds)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    LightningStrike();
    //}

    private void LightningStrike()
    {
        //_lightningParticle.SetActive(true);
        //_hitbox.SetActive(true);
        SetActiveState(true);
    }

    private void SetActiveState(bool activeState)
    {
        _lightningParticle.SetActive(activeState);
        _hitbox.SetActive(activeState);
    }

    public void CloudDieAnimation()
    {
        _isPlayerHitCloud = true;
        _animator.SetBool(_isDeadParam, true);

        StartCoroutine(RemoveCloud(1.4f));

       
    }

    IEnumerator RemoveCloud(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        this.gameObject.SetActive(false);
    }

    //public void CloudSQuash()
    //{
    //    _squish = .6f;
    //    _squishFrame = 0;
    //}
}
