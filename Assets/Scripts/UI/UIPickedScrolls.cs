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
                _psb.setTextInScroll(LikeADatabase._texts[0], LikeADatabase._titles[0]);
            }
        }

        if (IsScroll02Picked)
        {
            _pickedScroll02.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                _uiScroll.SetActive(true);
                _psb.setTextInScroll(LikeADatabase._texts[1], LikeADatabase._titles[1]);
            }
        }

        if (IsScroll03Picked)
        {
            _pickedScroll03.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                _uiScroll.SetActive(true);
                _psb.setTextInScroll(LikeADatabase._texts[2], LikeADatabase._titles[2]);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _uiScroll.SetActive(false);
        }
    }
}
