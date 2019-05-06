using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField]
    private Animator _endboss;

    [SerializeField]
    private GameObject _restartPanel;

    [SerializeField]
    private GameObject _PauzePanel;
    
    private float timer = 0;
    

    // Update is called once per frame
    void Update()
    {
        if (_endboss.GetBool("BossIsFree"))
        {
            timer += Time.deltaTime;

            if (timer > 2.5f)
            {
                _restartPanel.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _restartPanel.SetActive(false);
                GoToMainMenu();
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            _PauzePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _PauzePanel.SetActive(false);
    }
}
