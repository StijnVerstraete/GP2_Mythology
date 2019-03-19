using System;
using UnityEngine;

public class PickupController : MonoBehaviour
{

    #region Fields

    //--- private
    static GameObject _scrollUIPrefab, _scrollUIGO, _dialogUIPrefab, _dialogGO;

    //--- public
    static public bool IsActive;

    #endregion

    #region Methods

    void Start()
    {
        
        // Load the prefab.
        _scrollUIPrefab = (GameObject)Resources.Load("Prefabs/UI_Scroll", typeof(GameObject));
        _dialogUIPrefab = (GameObject)Resources.Load("Prefabs/UI_Dialog", typeof(GameObject));

        // Instantiate the prefab as a GameObject.
        _scrollUIGO = Instantiate(_scrollUIPrefab);
        _dialogGO = Instantiate(_dialogUIPrefab);

        // Disable the GameObject so the player doesn't see the GUI when not supposed to.
        _scrollUIGO.SetActive(false);
        _dialogGO.SetActive(false);

        // Set the main camera as the render camera
        _scrollUIGO.GetComponent<Canvas>().worldCamera = Camera.main;
        _dialogGO.GetComponent<Canvas>().worldCamera = Camera.main;
        
        //Debug.Log("Initialized PickupController");
    }

    static public void Pickup(string _pickupType)
    {
        switch (_pickupType)
        {
            case "scroll_1":
                // TODO: argument should be the string containing text on scroll.
                ActivateUI(_scrollUIGO);
                break;
            case "endboss":
                // TODO: argument should be the string containing text on scroll.
                ActivateUI(_dialogGO);
                break;
            default:
                break;
        }
    }

    static void ActivateUI(GameObject _go)
    {
        IsActive = true;
        _go.SetActive(true);
    }

    #endregion

}
