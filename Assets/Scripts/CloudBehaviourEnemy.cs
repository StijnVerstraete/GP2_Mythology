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
            // ShootLightningbolt();
            LightningStrike();

        }
        else if (_timer > 9)
        {
            _isShoot = false;
            _timer = 0;
            _lightningParticle.SetActive(false);
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

    //private void ShootLightningbolt()
    //{
    //    if (!_isShoot)
    //    {
    //        Instantiate(_lightningbolt, _lightningPosition.position, _lightningPosition.rotation);
    //        _isShoot = true;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
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
        //Debug.Log("lightning");
        //// Cast a ray straight down.
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, _groundMask);

        //// If it hits something...
        //if (hit.collider != null)
        //{

        //    // Calculate the distance from the surface and the "error" relative
        //    // to the floating height.
        //    float distance = Mathf.Abs(hit.point.y - transform.position.y);
        //    //Debug.DrawRay(this.transform.position, hit.point, Color.green);

        //    //Debug.Log(distance);

        //    //Debug.DrawLine(this.transform.position, this.transform.position - new Vector3(0,distance,0));
        //    //_lightningBox.GetComponent<LineRenderer>().SetPosition(0, this.transform.position);

        //    //_lightningBox.GetComponent<LineRenderer>().SetPosition(1, this.transform.position - new Vector3(-0.5f, distance - 1.2f, 0));
        //    //_lightningBox.GetComponent<LineRenderer>().SetPosition(2, this.transform.position - new Vector3(0.2f, distance + 1.1f * -1, 0));

        //    //_lightningBox.GetComponent<LineRenderer>().SetPosition(3, this.transform.position - new Vector3(-0.2f, distance, 0));



        //    //_lightningBox.GetComponent<BoxCollider2D>().offset = new Vector2(0, -(distance/2));
        //    //_lightningBox.GetComponent<BoxCollider2D>().size = new Vector2(1, distance);
        //}
    }
}
