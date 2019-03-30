using System;
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
    string[] _correctAnswersList = new string[]
    {
        "B",
        "C",
        "A"
    };
    int _currentQuestion, _correctAnswers;

    #endregion

    #region Properties

    public PickupHandler ConnectedPickupHandler { get; set; }

    #endregion

    #region Methods

    private void Awake()
    {
        FillQuestions();
    }

    void FillQuestions()
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
    }

    public void SelectOption(string _answer)
    {
        ProcessAnswer(_answer);
        if (_currentQuestion < 2) HandleQuestions();
        else DisableMe();
    }

    void ProcessAnswer(string _answer)
    {
        if (_correctAnswersList[_currentQuestion] == _answer) _correctAnswers++;
        Debug.Log(string.Format("Player selected option: {0}, correct answers: {1}", _answer, _correctAnswers));
    }

    void HandleQuestions()
    {
        _currentQuestion++;
        FillQuestions();
    }

    #endregion
}
