using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPickedScrolls : MonoBehaviour
{
    public bool IsScroll01Picked { get; set; }
    public bool IsScroll02Picked { get; set; }
    public bool IsScroll03Picked { get; set; }

    [SerializeField]
    private GameObject _uiScroll;
    [SerializeField]
    private GameObject _pickedScroll01;
    [SerializeField]
    private GameObject _pickedScroll02;
    [SerializeField]
    private GameObject _pickedScroll03;

    private string[] _titles = new string[] { "First scroll" , "Second scroll", "Third scroll" };
    private string[] _texts = new string[]
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

    private PickedScrollBehaviour _psb;

    // Start is called before the first frame update
    void Start()
    {
        _pickedScroll01.SetActive(false);
        _pickedScroll02.SetActive(false);
        _pickedScroll03.SetActive(false);
        _uiScroll.SetActive(false);
        _psb = _uiScroll.GetComponent<PickedScrollBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsScroll01Picked)
        {
            _pickedScroll01.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                _uiScroll.SetActive(true);
                _psb.setTextInScroll(_texts[0], _titles[0]);
            }
        }

        if (IsScroll02Picked)
        {
            _pickedScroll02.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                _uiScroll.SetActive(true);
                _psb.setTextInScroll(_texts[1], _titles[1]);
            }
        }

        if (IsScroll03Picked)
        {
            _pickedScroll03.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                _uiScroll.SetActive(true);
                _psb.setTextInScroll(_texts[2], _titles[2]);
            }
        }

        

        

        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _uiScroll.SetActive(false);
        }
    }
}
