using UnityEngine;
using UnityEngine.UI;

public class UIHandler_Scroll : MonoBehaviour
{

    #region Fields

    //--- Public
    public Text TextBox, Title;

    //--- Private
    int _currentText;
    string[] _texts = new string[]
    {
        // First text
        "Kronos, titan of time, was prophesised to be overthrown by one of his children. " +
        "To prevent this, he decided to devour them. " +
        "Hestia, Demeter, Hera, Hades and Poseidon all suffered this fate. " +
        "His wife, Rhea, decided to hide the last one, Zeus. " +
        "When Zeus had grown strong enough, he challenged Kronos and defeated him, " +
        "retrieving his brothers and sisters from the titan's belly.",

        // Second text
        "When Zeus had a relationship with the human Semele, Zeus' wife Hera was unhappy. " +
        "When Semele strode around bragging about her boyfriend being the god of the sky, " +
        "Hera disguised herself as an human and asked Semele if she had any proof he was actually Zeus. " +
        "Peeved, Semele demanded Zeus prove to her his godly nature, by revealing his true glory. " +
        "Zeus refused, but she insisted. When he showed his true self, the glory was too much, " +
        "and Semele disintegrated, leaving behind the unborn baby Dionysos. " +
        "Zeus managed to sow Dionysos into his thigh, where the baby grew healthy. ",

        // Third text
        "Zeus resides on Mount Olympus as king of the gods. " +
        "He rules over the sky and over his brothers, who are kings in their own right. " +
        "Despite being one of the most powerful beings in existence, Zeus' rule is under a constant threat. " +
        "Many Romans believed his son Apollo would overthrow him and become a new king. " +
        "It was prophesised Athena, his daughter, could defeat him if she chose so. " +
        "The titans and older beings clambered for any opportunity to return from their various prisons and take back the power. " +
        "All this caused some of Zeus' behaviour to be erratic and paranoid. "
    };

    #endregion

    #region Properties

    public PickupHandler ConnectedPickupHandler { get; set; }

    #endregion

    #region Methods

    private void Awake()
    {
        Invoke("DelayedStart", 1);
    }

    private void DelayedStart()
    {
        switch (gameObject.tag)
        {
            case "scroll_1":
                TextBox.text = _texts[0];
                Title.text = "First scroll";
                break;
            case "scroll_2":
                TextBox.text = _texts[1];
                Title.text = "Second scroll";
                break;
            case "scroll_3":
                TextBox.text = _texts[2];
                Title.text = "Third scroll";
                break;
            default:
                break;
        }
    }

    public void DisableMe()
    {
        ConnectedPickupHandler.DisableActiveUI();
    }

    #endregion
}
