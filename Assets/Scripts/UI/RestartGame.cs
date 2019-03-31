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


    private bool _showRestartPanel = false;
    private float timer = 0;
    

    // Update is called once per frame
    void Update()
    {
        if (_endboss.GetBool("BossIsFree"))
        {
            _showRestartPanel = true;
        }

        if (_showRestartPanel)
        {
            timer += Time.deltaTime;

            if (timer > 3)
            {
                _restartPanel.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _restartPanel.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }
}
