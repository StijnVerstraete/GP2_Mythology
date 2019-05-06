using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CinematicMode
{

    #region Fields

    //--- Private
    static bool _isActive, _isInitiated;
    static Camera _activeCamera;
    static float _scale = .75f;
    static float _blendValue = 0f;
    static float _cameraZoomTarget, _initialValue;
    static readonly float _blendIncreaseStep = .0005f;
    static GameObject[] _borders;

    //--- Public

    #endregion

    #region Properties

    static public bool Active { get => _isActive; }
    static public bool Initialized { get => _isInitiated; }

    #endregion

    #region Methods

    public static void Toggle() {
        _isActive = !_isActive;
        CinematicEffects();
    }

    static void CinematicEffects()
    {
        if (_activeCamera == null) RecoverComponents();
        GetTargetZoom();
    }

    private static void GetTargetZoom()
    {
        _cameraZoomTarget = Active ? _activeCamera.orthographicSize * _scale : _activeCamera.orthographicSize / _scale;
        _cameraZoomTarget = Mathf.Clamp(_cameraZoomTarget, 5.4f, 7.2f);
    }

    static void RecoverComponents()
    {
        _activeCamera = Camera.main;
        _cameraZoomTarget = _activeCamera.orthographicSize;
        _borders = _activeCamera.GetComponent<CameraController>().CameraBorders;
        _isInitiated = true;
    }

    public static void HandleBlend()
    {
        float _currentSize = _activeCamera.orthographicSize;

        // Stop if camera is almost in position
        if (Mathf.Abs(Round(_cameraZoomTarget, 1) - Round(_currentSize, 1)) < .1f) return;

        BlendCam();
    }

    static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }

    static void BlendCam()
    {
        float _currentSize = _activeCamera.orthographicSize;
        if (Active) _blendValue += _blendIncreaseStep;
        else _blendValue -= _blendIncreaseStep;
        //Debug.Log(string.Format(
        //    "Blending camera (++) with value: {2} ({0} / {1})",
        //    _currentSize,
        //    _cameraZoomTarget,
        //    Mathf.Lerp(_currentSize, _cameraZoomTarget, _blendValue)
        //));
        _activeCamera.orthographicSize = Mathf.Lerp(_currentSize, _cameraZoomTarget, _blendValue);
        HandleCamBorders();
    }

    private static void HandleCamBorders()
    {
        Vector3 _top = _borders[0].transform.position;
        Vector3 _bottom = _borders[1].transform.position;
        float _pos = _top.y;
        float _pos2 = _bottom.y;
        if (Active)
        {
            _pos--;
            _pos2++;
        }
        else {
            _pos++;
            _pos2--;
        }

        Mathf.Clamp(_pos, -50, 50);
        Mathf.Clamp(_pos2, -50, 50);

        _top.y = _pos;
        _bottom.y = _pos2;

        _borders[0].transform.position = _top;
        _borders[1].transform.position = _bottom;
    }

    #endregion
}
