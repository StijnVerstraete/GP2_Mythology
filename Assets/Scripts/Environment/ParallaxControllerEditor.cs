using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;

[CustomEditor(typeof(ParallaxController))]
public class ParallaxControllerEditor : Editor
{
    List<bool> _showFloat = new List<bool>();
    ParallaxController _parallaxCon;

    public override void OnInspectorGUI()
    {

        // Show default inspector property editor
        DrawDefaultInspector();

        _parallaxCon = (ParallaxController)target;

        GUILayout.Label("Freeze layer when player idle:", EditorStyles.boldLabel);

        if (_showFloat.Count == 0) FillList();
        if (_showFloat.Count != _parallaxCon.ParallaxLayers.Length) RefreshList();

        for (int i = 0; i < _parallaxCon.ParallaxLayers.Length; i++) HandleToggle(i); 

    }

    private void RefreshList()
    {
        List<bool> _showFloatTemp = _showFloat;
        _showFloat.Clear();
        for (int i = 0; i < _parallaxCon.ParallaxLayers.Length; i++) AddValueToCollection(_showFloatTemp[i]);
        Debug.Log("Refreshed list!");
    }

    private void FillList()
    {
        _showFloat.Clear();
        for (int i = 0; i < _parallaxCon.ParallaxLayers.Length; i++) AddValueToCollection(false);
        Debug.Log("Re-filled list!");
    }

    private void AddValueToCollection(bool value)
    {
        Debug.Log(string.Format("Added {0}", value));
        _showFloat.Add(value);
    }

    private void HandleToggle(int i)
    {
        _showFloat[i] = EditorGUILayout.Toggle(string.Format("Layer {0}", i), _showFloat[i]);
        if (!_showFloat[i]) _showFloat[i] = true;
        else if (_showFloat[i]) _showFloat[i] = false;
    }
}
