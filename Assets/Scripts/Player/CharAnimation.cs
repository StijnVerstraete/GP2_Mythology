﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimation : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _player;

    // Update is called once per frame
    void Update()
    {
        //set IsRunning
        if (_player.GetComponent<Rigidbody2D>().velocity.x != 0)
        {
            _anim.SetBool("IsRunning", true);
            Debug.Log("IsRunning");
        }
        else
        {
            _anim.SetBool("IsRunning", false);
        }
        //set isJumping && isFalling
        if (_player.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            _anim.SetBool("IsJumping", true);
            Debug.Log("IsJumping");
        }
        else if (_player.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            _anim.SetBool("IsFalling", true);
            _anim.SetBool("IsJumping", false);
            Debug.Log("IsFalilng");
        }
        else
        {
            _anim.SetBool("IsFalling", false);
        }
    }
}
