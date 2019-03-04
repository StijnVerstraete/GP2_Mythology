using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;

[CustomEditor(typeof(ParallaxController))]
public class ParallaxControllerEditor : Editor
{
    ParallaxController _parallaxCon;

    public override void OnInspectorGUI()
    {

        // Show default inspector property editor
        DrawDefaultInspector();

        _parallaxCon = (ParallaxController)target;

        GUILayout.Label("Freeze layer when player idle:", EditorStyles.boldLabel);

        if (_parallaxCon.ShowFloat.Count == 0) FillList();
        if (_parallaxCon.ShowFloat.Count != _parallaxCon.ParallaxLayers.Length) RefreshList();

        for (int i = 0; i < _parallaxCon.ParallaxLayers.Length; i++) HandleToggle(i);


        GUILayout.Label("Set custom speed for parallax effect:", EditorStyles.boldLabel);

        if (_parallaxCon.ParallaxSpeeds.Count == 0) FillFloatList();
        if (_parallaxCon.ParallaxSpeeds.Count != _parallaxCon.ParallaxLayers.Length) RefreshFloatList();

        for (int i = 0; i < _parallaxCon.ParallaxLayers.Length; i++) HandleFloats(i);
    }

    private void RefreshList()
    {
        List<bool> _showFloatTemp = _parallaxCon.ShowFloat;
        _parallaxCon.ShowFloat.Clear();
        for (int i = 0; i < _parallaxCon.ParallaxLayers.Length; i++) AddValueToCollection(_showFloatTemp[i]);
        Debug.Log("Refreshed list!");
    }

    private void RefreshFloatList()
    {
        List<float> _parallaxSpeedsTemp = _parallaxCon.ParallaxSpeeds;
        _parallaxCon.ShowFloat.Clear();
        for (int i = 0; i < _parallaxCon.ParallaxLayers.Length; i++) _parallaxCon.ParallaxSpeeds.Add(_parallaxSpeedsTemp[i]);
        Debug.Log("Refreshed list!");
    }

    private void FillList()
    {
        _parallaxCon.ShowFloat.Clear();
        for (int i = 0; i < _parallaxCon.ParallaxLayers.Length; i++) AddValueToCollection(false);
        Debug.Log("Re-filled list!");
    }

    private void FillFloatList()
    {
        _parallaxCon.ParallaxSpeeds.Clear();
        for (int i = 0; i < _parallaxCon.ParallaxLayers.Length; i++) _parallaxCon.ParallaxSpeeds.Add(0f);
        Debug.Log("Re-filled list!");
    }

    private void AddValueToCollection(bool value)
    {
        Debug.Log(string.Format("Added {0}", value));
        _parallaxCon.ShowFloat.Add(value);
    }

    private void HandleToggle(int i)
    {
        _parallaxCon.ShowFloat[i] = EditorGUILayout.Toggle(string.Format("{0}", _parallaxCon.ParallaxLayers[i].name), _parallaxCon.ShowFloat[i]);
        if (!_parallaxCon.ShowFloat[i]) _parallaxCon.ShowFloat[i] = true;
        else if (_parallaxCon.ShowFloat[i]) _parallaxCon.ShowFloat[i] = false;
    }

    private void HandleFloats(int i)
    {
        _parallaxCon.ParallaxSpeeds[i] = EditorGUILayout.FloatField(_parallaxCon.ParallaxLayers[i].name, _parallaxCon.ParallaxSpeeds[i]);
    }
}
