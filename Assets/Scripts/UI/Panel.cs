using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public class Panel : InputField
{
    [SerializeField]
    private TMP_Text pause_overText;
    [SerializeField]
    private TMP_Text resume_restartText;
    [SerializeField]
    private TMP_Text exit_text;
    public GameObject restarPanel;
    public GameObject savePanel;
    public GameObject dataManager;


    public void OnPause()
    {
        pause_overText.color = Color.cyan;
        pause_overText.text = "Pause";
        resume_restartText.text = "Resume";
        if(gc.state == GameController.eState.Onpause)
        {
            restarPanel.SetActive(true);
            savePanel.SetActive(true);
        }
        
     
    }

    public void Resume()
    {
       
            gameObject.SetActive(false);
            gc.Resume();
        
       
    }

    public void OnGameOver()
    {
        pause_overText.color = Color.red;
        pause_overText.text = "Game Over";
        resume_restartText.text = "Restart";
        savePanel.SetActive(false);
        restarPanel.SetActive(false);
    }
}
