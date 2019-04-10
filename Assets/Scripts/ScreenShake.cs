using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    [SerializeField]  private Transform _camTransform;

    public float ShakeDuration;

    private float _shakeAmount = 2f;
    private float _decreaseFactor = 1.0f;

    private Vector3 _originalPos;

    void Start()
    {
        _originalPos = _camTransform.localPosition;
    }

    void Update()
    {
        if (ShakeDuration > 0)
        {
            _camTransform.localPosition = _originalPos + Random.insideUnitSphere * _shakeAmount;

            ShakeDuration -= Time.deltaTime * _decreaseFactor;
        }
        else
        {
            ShakeDuration = 0f;
            _camTransform.localPosition = _originalPos;
            enabled = false;
        }
    }
}
