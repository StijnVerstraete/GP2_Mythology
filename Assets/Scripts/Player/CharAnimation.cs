using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CharAnimation : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _player;

    // Update is called once per frame
    void Update()
    {
        //set falling
        if (_player.GetComponent<Rigidbody2D>().velocity.y > 0.1f)
        {
            _anim.SetBool("IsJumping", true);
            _anim.SetBool("IsFalling", false);
        }
        //set hanging
        else if (!_player.GetComponent<PlayerController>().Ground.IsGrounded)
        {
            
            _anim.SetBool("IsJumping", false);
            _anim.SetBool("IsFalling", true);
        }
        //setrunning
        else if(_player.GetComponent<Rigidbody2D>().velocity.x != 0)
        {
            _anim.SetBool("IsRunning", true);
            _anim.SetBool("IsFalling", false);
        }
        //setidling
        else
        {
            _anim.SetBool("IsIdling",true);
            _anim.SetBool("IsRunning", false);
        }
    }
}
