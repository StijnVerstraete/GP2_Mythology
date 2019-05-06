using System;
using System.Collections.Generic;
using System.Linq;
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
    private PlayerController _player;

    List<string> _correctQuestions = new List<string>();
    List<string> _correctResponses = new List<string>();
    List<string[]> _correctAnswersGiven = new List<string[]>();

    //bossparticle
    [SerializeField] private GameObject _bossParticle;

    //string[] _questions = new string[]
    //{
    //    "What did Kronos do to Zeus' siblings?",
    //    "What happened to Semele?",
    //    "Where does Zeus rule from?"
    //};
    //string[][] _answers = new string[][]
    //{
    //    new string[]
    //    {
    //        "A) He raised them to resent Zeus.",
    //        "B) He ate them.", // (correct)
    //        "C) He made them fight each other to the death, until only Zeus was left."
    //    },
    //    new string[]
    //    {
    //        "A) She was stabbed in the gut by Hera, Zeus' angry wife.",
    //        "B) She was devoured by her father, but then resqued by her brother, Zeus.",
    //        "C) She was disintegrated by Zeus' glory." // (correct)
    //    },
    //    new string[]
    //    {
    //        "A) Mount Olympus.", // (correct)
    //        "B) The House of Athens.",
    //        "C) The Great Hill of Singapore."
    //    }
    //};
    //string[] _correctAnswersList = new string[]
    //{
    //    "B",
    //    "C",
    //    "A"
    //};
    int _currentQuestion, _correctAnswers;
    string[] _allQuestions, _allCorrectAnswers;
    string[][] _allAnswers;

    #endregion

    #region Properties

    public PickupHandler ConnectedPickupHandler { get; set; }

    #endregion

    #region Methods
    
    private void Awake()
    {
        // Recover all questions
        _allQuestions = LikeADatabase._questions;
        _allAnswers = LikeADatabase._answers;
        _allCorrectAnswers = LikeADatabase._correctAnswersList;

        FillQuestions();

        _bossParticle = GameObject.Find("Endboss");

        Debug.Log(_bossParticle);
    }
    

    void FillQuestions()
    {
        //TextBox.text = _questions[_currentQuestion];

        // Filter out all questions
        List<string> _validQuestions = _allQuestions.Where(s => !_correctQuestions.Contains(s)).ToList();

        // Filter out all answers
        List<string[]> _validAnswers = _allAnswers.Where(a => !_correctAnswersGiven.Contains(a)).ToList();

        // If question out of bounds, reduce it
        if (_currentQuestion > _validQuestions.Count - 1) _currentQuestion = 0;

        // Apply the question
        TextBox.text = _validQuestions[_currentQuestion];

        // Recover corresponding answers

        Debug.Log(
            string.Format(
                    "Filtered questions: {0} / Selected question: {1} / Recovered answers: {2}",
                    string.Join(", ", _validQuestions),
                    _currentQuestion,
                    string.Join(", ", _validAnswers)
                )
            );

        // Apply the answers
        for (int i = 0; i < AnswerTexts.Length; i++)
        {
            AnswerTexts[i].text = _validAnswers[_currentQuestion][i];
        }
    }

    public void DisableMe()
    {
        ConnectedPickupHandler.DisableActiveUI();
    }

    public void SelectOption(string _answer)
    {
        ProcessAnswer(_answer);
        if (_correctAnswersGiven.Count < 3) HandleQuestions();
        else DisableMe();
    }

    void ProcessAnswer(string _answer)
    {
        // Filter out all correct answers
        List<string> _validCorrectAnswers = _allCorrectAnswers.Where(a => !_correctResponses.Contains(a)).ToList();

        Debug.Log(string.Format("Answered: {0}, correct: {1}", _answer, _validCorrectAnswers[_currentQuestion]));

        if (_validCorrectAnswers[_currentQuestion] == _answer)
        {
            _correctQuestions.Add(_allQuestions[_currentQuestion]);
            _correctResponses.Add(_allCorrectAnswers[_currentQuestion]);
            _correctAnswersGiven.Add(_allAnswers[_currentQuestion]);
        }
        else
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            _player.TakeDamage();
        }
        Debug.Log(string.Format("Player selected option: {0}, correct answers: {1}", _answer, _correctAnswersGiven.Count));


        if (_correctAnswersGiven.Count == 3)
        {
            GameObject.Find("Endboss").GetComponent<Animator>().SetBool("BossIsFree", true);
            _bossParticle.SetActive(true);
        }
    }

    void HandleQuestions()
    {
        _currentQuestion++;
        FillQuestions();
    }

    #endregion
}
