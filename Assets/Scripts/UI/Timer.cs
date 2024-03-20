using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour, IDataPersistence
{
    public TMP_Text timeText;
    public float timeRemaning=0;
    public GameController gc;
    public bool IsRunning = false;




   public void Update()
    {
        if (IsRunning == true)
        {   
                timeRemaning += Time.deltaTime;
                DisplayTime(timeRemaning);
        }
    }

    
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    public void LoadData(GameData data)
    {
        this.timeRemaning = data.currentTime;
       
    }

    public void SaveData(ref GameData data)
    {

        data.currentTime = this.timeRemaning;
    }
}
