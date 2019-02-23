using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlayerPlatform : MonoBehaviour
{
    private bool _moving;

    private bool test;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_moving)
        {
            this.transform.position += Vector3.right * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.layer == 9)
        {
            _moving = true;
            collision.transform.SetParent(this.transform);
        }

        if (collision.gameObject.tag == "stopPlatform")
        {
            _moving = false;
            collision.transform.SetParent(null);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            _moving = false;
            collision.transform.SetParent(null);
        }
    }
}
