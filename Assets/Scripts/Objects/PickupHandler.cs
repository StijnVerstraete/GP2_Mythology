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
        _UIGO.tag = gameObject.tag;

        // Set current GO as parent
        //_UIGO.transform.SetParent(gameObject.transform);

        // Set this controller as the connected one.
        switch (gameObject.tag)
        {
            case "scroll_1":
                _UIGO.GetComponent<UIHandler_Scroll>().ConnectedPickupHandler = this;
                break;
            case "scroll_2":
                _UIGO.GetComponent<UIHandler_Scroll>().ConnectedPickupHandler = this;
                break;
            case "scroll_3":
                _UIGO.GetComponent<UIHandler_Scroll>().ConnectedPickupHandler = this;
                break;
            case "endboss":
                _UIGO.GetComponent<UIHandler>().ConnectedPickupHandler = this;
                break;
            default:
                break;
        }

        // Disable the GameObject so the player doesn't see the GUI when not supposed to.
        _UIGO.SetActive(false);

        // Set the main camera as the render camera
        _UIGO.GetComponent<Canvas>().worldCamera = Camera.main;

        //Debug.Log(string.Format("Initialized {0}", gameObject.tag));
        
    }

    GameObject AutoInstantiate()
    {
        string _class = "";
        switch (gameObject.tag)
        {
            case "scroll_1":
                _class = "Prefabs/UI_Scroll";
                break;
            case "scroll_2":
                _class = "Prefabs/UI_Scroll";
                break;
            case "scroll_3":
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
        // if (collision.gameObject.tag == "Player") HandlePickup();

        if (collision.gameObject.tag == "Player") {
            HandlePickup();
            
            //search for the pickedscrolls gameobject
            UIPickedScrolls scroll = GameObject.Find("PickedScrolls").GetComponent<UIPickedScrolls>();

            //set the correct panel active so the player can press a number to read the scroll again
            switch (gameObject.tag)
            {
                case "scroll_1":
                    scroll.IsScroll01Picked = true;
                    break;
                case "scroll_2":
                    scroll.IsScroll02Picked = true;
                    break;
                case "scroll_3":
                    scroll.IsScroll03Picked = true;
                    break;
                default:
                    break;
            }
        } 
    }

    void HandlePickup()
    {
        _UIGO.SetActive(true);
        _player.IsHandlingUI = true;

        string _theTag = gameObject.tag;
        //if (_theTag == "scroll_1" || _theTag == "scroll_2" || _theTag == "scroll_3") gameObject.SetActive(false);

        if (_theTag == "scroll_1" || _theTag == "scroll_2" || _theTag == "scroll_3") {
            gameObject.SetActive(false);
            Time.timeScale = 0; // if player pick up a scroll everything stops moving so you don't have to worry to be hit by an cloud
        }
        

        // If UI is child
        //gameObject.GetComponent<Renderer>().enabled = false;
    }
    #endregion

}
