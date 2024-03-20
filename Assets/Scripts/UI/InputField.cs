using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using UnityEngine.SocialPlatforms.Impl;

public class InputField : MonoBehaviour
{
    [SerializeField]
    private string inputText;
    public int solution;
    [SerializeField]
    private TMP_InputField inputTextField;
    private string empty = "";
    public GameController gc;
    public Valutation valutation;
    [SerializeField]
    private GameObject pausePanel;
    public Panel panel;

    public void Start()
    {
        if (inputTextField != null)
        {
            StartCoroutine(TakeInputField());
        }
    }

    IEnumerator TakeInputField()
    {
        while (gc.state != GameController.eState.OnGameOver)
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                    panel.OnPause();
                    pausePanel.SetActive(true);
                    gc.OnPause();
                
            }
            if (!inputTextField.isFocused)
            {
                inputTextField.ActivateInputField();
            }
            yield return null;
        }

        if (gc.state == GameController.eState.OnGameOver)
        {
                panel.OnGameOver();
                pausePanel.SetActive(true);
        }
    }
 
    

    public void TakeInput(string text)
    {
        if (Int32.TryParse(text, out int result))
        {
            
            inputText = text;
            solution = Convert.ToInt32(text);
            solution = result;
            valutation.ReserchSolution(solution);
            ClearInput();
        }
       
    }

   



    public void ClearInput() => inputTextField.text = empty;


}
