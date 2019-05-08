using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
    [SerializeField]
    private Transform[] Waypoints;

    [SerializeField]
    private float _speed = 1;

    private int _index = 0;

    #region Properties

    public bool MovingRight { get => _index == Waypoints.Length - 1; }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = Waypoints[_index].position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatformBetweenWaypoints();
    }

    private void MovePlatformBetweenWaypoints()
    {
        if (Vector3.Distance(transform.position, Waypoints[_index].position) <= _speed * Time.deltaTime)
        {
            ++_index;
            _index %= Waypoints.Length;
        }

        this.transform.position = Vector3.MoveTowards(transform.position, Waypoints[_index].transform.position, _speed * Time.deltaTime);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 9)
    //    {
    //        collision.transform.SetParent(this.transform);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 9)
    //    {
    //        collision.transform.SetParent(null);
    //    }
    //}
}
