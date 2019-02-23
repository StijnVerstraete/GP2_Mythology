using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPlatform : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _platforms = new List<Transform>();

    [SerializeField]
    private float _speed = 1; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.forward * _speed * Time.deltaTime);

        foreach (Transform item in _platforms)
        {
            item.transform.rotation = Quaternion.Euler(new Vector3(0,0, -this.transform.rotation.z));
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.transform.SetParent(null);
        }
    }
}
