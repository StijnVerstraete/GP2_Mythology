using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    #region Fields

    //--- Public
    public Text TextBox;
    public GameObject[] AnswerButtons;
    public Text[] AnswerTexts;

    //--- Private
    string[] _questions = new string[]
    {
        "What did Kronos do to Zeus' siblings?",
        "What happened to Semele?",
        "Where does Zeus rule from?"
    };
    string[][] _answers = new string[][]
    {
        new string[]
        {
            "A) He raised them to resent Zeus.",
            "B) He ate them.", // (correct)
            "C) He made them fight each other to the death, until only Zeus was left."
        },
        new string[]
        {
            "A) She was stabbed in the gut by Hera, Zeus' angry wife.",
            "B) She was devoured by her father, but then resqued by her brother, Zeus.",
            "C) She was disintegrated by Zeus' glory." // (correct)
        },
        new string[]
        {
            "A) Mount Olympus.", // (correct)
            "B) The House of Athens.",
            "C) The Great Hill of Singapore."
        }
    };
    int _currentQuestion;

    #endregion

    #region Properties

    public PickupHandler ConnectedPickupHandler { get; set; }

    #endregion

    #region Methods

    private void Awake()
    {
        TextBox.text = _questions[_currentQuestion];
        for (int i = 0; i < AnswerTexts.Length; i++)
        {
            AnswerTexts[i].text = _answers[_currentQuestion][i];
        }
    }

    public void DisableMe()
    {
        ConnectedPickupHandler.DisableActiveUI();
        if (_currentQuestion < 2) _currentQuestion++;
    }

    public void SelectOption(string _s)
    {
        Debug.Log(string.Format("Player selected option: {0}", _s));
        DisableMe();
    }

    #endregion
}
