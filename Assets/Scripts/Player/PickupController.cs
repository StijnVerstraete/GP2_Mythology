using UnityEngine;

public class PickupController : MonoBehaviour
{

    #region Fields

    //--- private
    static GameObject _scrollUIPrefab, _scrollUIGO;

    #endregion

    #region Methods

    void Start()
    {
        // Load the prefab.
        _scrollUIPrefab = (GameObject)Resources.Load("Prefabs/UI_Scroll", typeof(GameObject));

        // Instantiate the prefab as a GameObject.
        _scrollUIGO = Instantiate(_scrollUIPrefab);

        // Disable the GameObject so the player doesn't see the GUI when not supposed to.
        _scrollUIGO.SetActive(false);

        // Set the main camera as the render camera
        _scrollUIGO.GetComponent<Canvas>().worldCamera = Camera.main;
        
        //Debug.Log("Initialized PickupController");
    }

    static public void Pickup(string _pickupType)
    {
        switch (_pickupType)
        {
            case "scroll_1":
                // TODO: argument should be the string containing text on scroll.
                ShowScroll("placeholder text");
                break;
            default:
                break;
        }
    }

    static void ShowScroll(string _v)
    {
        // Enables the GUI for the player to see and interact with.
        _scrollUIGO.SetActive(true);
    }

    #endregion

}
