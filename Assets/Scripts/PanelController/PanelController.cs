using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    [SerializeField] GameObject _pausePanel, _goPanel;



    public void PauseButton()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
        
    }


    public void RestartButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
        _goPanel.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }


}
