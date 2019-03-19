using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    public Text TextBox;
    public GameObject[] AnswerButtons;
    public Text[] AnswerTexts;
    public string Question;
    public string[] Answers;

    public PickupHandler ConnectedPickupHandler { get; set; }

    private void Awake()
    {
        TextBox.text = Question;
        for (int i = 0; i < AnswerTexts.Length; i++)
        {
            AnswerTexts[i].text = Answers[i];
        }
    }

    public void DisableMe()
    {
        ConnectedPickupHandler.DisableActiveUI();
    }

    public void SelectOption(string _s)
    {
        Debug.Log(string.Format("Player selected option: {0}", _s));
        DisableMe();
    }
}
