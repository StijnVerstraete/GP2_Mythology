using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
    }
}
