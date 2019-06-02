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
    static int _borderOffset = 4;
    static float _incrementValue = 0f;
    static Vector3 _botPos, _topPos;

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

    static void GetTargetZoom()
    {
        _cameraZoomTarget = Active ? _activeCamera.orthographicSize * _scale : _activeCamera.orthographicSize / _scale;
        _cameraZoomTarget = Mathf.Clamp(_cameraZoomTarget, 5.4f, 7.2f);
    }

    static void RecoverComponents()
    {
        _activeCamera = Camera.main;
        _cameraZoomTarget = _activeCamera.orthographicSize;
        _borders = _activeCamera.GetComponent<CameraController>().CameraBorders;
        _topPos = _borders[0].transform.localPosition;
        _botPos = _borders[1].transform.localPosition;
       // Debug.Log(string.Format("{0}, {1}", _topPos, _botPos));
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

    static void HandleCamBorders()
    {
        if (Active)
        {
            _incrementValue += .01f;
        }
        else
        {
            _incrementValue -= .01f;
        }
        _incrementValue = Mathf.Clamp(_incrementValue, 0f, 1f);
        HandleTopBorder();
        HandleBottomBorder();
    }

    static void HandleTopBorder()
    {
        Vector3 _tempPosition = _topPos;
        _tempPosition.z = Mathf.Lerp(_topPos.z - _borderOffset, _topPos.z, 1 - _incrementValue);
        _borders[0].transform.localPosition = _tempPosition;
    }

    static void HandleBottomBorder()
    {
        Vector3 _tempPosition = _botPos;
        _tempPosition.z = Mathf.Lerp(_botPos.z, _botPos.z + _borderOffset, _incrementValue);
        _borders[1].transform.localPosition = _tempPosition;
    }

    #endregion
}
