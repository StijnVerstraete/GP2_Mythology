using UnityEngine;

public class PickupHandler : MonoBehaviour
{

    #region Fields

    //--- private
    GameObject _UIPrefab, _UIGO;
    PlayerController _player;

    #endregion

    #region Methods

    void Start()
    {

        // Recover the player
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        _UIGO = AutoInstantiate();

        // Set current GO as parent
        //_UIGO.transform.SetParent(gameObject.transform);

        // Set this controller as the connected one.
        _UIGO.GetComponent<UIHandler>().ConnectedPickupHandler = this;

        // Disable the GameObject so the player doesn't see the GUI when not supposed to.
        _UIGO.SetActive(false);

        // Set the main camera as the render camera
        _UIGO.GetComponent<Canvas>().worldCamera = Camera.main;

        Debug.Log(string.Format("Initialized {0}", gameObject.tag));
        
    }

    GameObject AutoInstantiate()
    {
        string _class = "";
        switch (gameObject.tag)
        {
            case "scroll_1":
                // TODO: argument should be the string containing text on scroll.
                _class = "Prefabs/UI_Scroll";
                break;
            case "endboss":
                _class = "Prefabs/UI_Dialog";
                break;
            default:
                break;
        }
        // Load the prefab & instantiate the prefab as a GameObject.
        return Instantiate((GameObject)Resources.Load(_class, typeof(GameObject)));
    }

    public void DisableActiveUI()
    {
        _UIGO.SetActive(false);
        _player.IsHandlingUI = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if collision with player
        if (collision.gameObject.tag == "Player") HandlePickup();
    }

    void HandlePickup()
    {
        _UIGO.SetActive(true);
        _player.IsHandlingUI = true;

        if (gameObject.tag == "scroll_1") gameObject.SetActive(false);

        // If UI is child
        //gameObject.GetComponent<Renderer>().enabled = false;
    }
    #endregion

}
