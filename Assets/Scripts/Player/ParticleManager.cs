using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private GameObject _runParticles;
    [SerializeField] private GameObject _jumpParticles;
    [SerializeField] private GameObject _charCTRL;


    private float _jumpParticleDelay = 0.5f;

    // Update is called once per frame
    void Update()
    {
        RunParticles();
        JumpParticles();
    }
    private void RunParticles()
    {
        //if (_charCTRL.GetComponent<Rigidbody2D>().velocity.x != 0 && _charCTRL.GetComponent<PlayerController>().Ground.IsGrounded)
        //{
        //    _runParticles.SetActive(true);
        //}
        //else
        //{
        //    _runParticles.SetActive(false);
        //}
        if ((_charCTRL.GetComponent<Rigidbody2D>().velocity.x >= 0.002 || _charCTRL.GetComponent<Rigidbody2D>().velocity.x <= -0.002) && _charCTRL.GetComponent<PlayerController>().Ground.IsGrounded)
        {
            _runParticles.SetActive(true);
        }
        else
        {
            _runParticles.SetActive(false);
        }
        
    }
    private void JumpParticles()
    {

        if (_charCTRL.GetComponent<PlayerController>().Ground.IsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _jumpParticles.SetActive(true);
        }
        else if (_jumpParticleDelay <= 0)
        {
            _jumpParticles.SetActive(false);
            _jumpParticleDelay = 0.5f;
        }
        if (_jumpParticles.activeSelf)
        {
            _jumpParticleDelay -= Time.deltaTime;
        }
    }
}
