using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.Controls.AxisControl;
using Unity.VisualScripting;
using System.Collections.ObjectModel;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public ObjectPool Pool;
    public Timer timer;
    public GameObject dataManager;
    private DataPersistenceManager manager;
    


    public enum eState
    {
        Onplay,
        Onpause,
        OnGameOver,
        OnMainMenu
    }
    public eState state;
   

    public void goToState(eState gameState)
    {
        state = gameState;

        switch (state)
        {
            case eState.Onplay:
                timer.IsRunning = true;
                Time.timeScale = 1;
                break;

            case eState.Onpause:
                timer.IsRunning = false;
                Time.timeScale = 0;
                break;

            case eState.OnGameOver:
                timer.IsRunning = false;
                Pool.poolObjects.Clear();
                break;

            case eState.OnMainMenu:
                break;

        }
    }


    public void Start()
    {
        goToState(eState.Onplay);//QUando inizia il gioco cerca il systemController e avvia il nuovo gioco
        dataManager = GameObject.FindWithTag("DataManager");
        manager=dataManager.GetComponent<DataPersistenceManager>();
        StartCoroutine(IncreaseVariableCoroutine());
    }

    public void OnSave()
    {
        if (dataManager != null)
        {

          manager.SaveGame();

        }
        else
        {
            // Emetti un messaggio di avviso se l'oggetto non è stato trovato
            Debug.LogWarning("Oggetto con tag 'dataManager' non trovato.");
        }
    }
    public void OnPause()
    {
        goToState(eState.Onpause);
    }

    public void Resume()
    {
        goToState(eState.Onplay);
        timer.Update();
    }

    private IEnumerator IncreaseVariableCoroutine()
    {
        while (Time.timeScale == 1)
        {
            yield return new WaitForSeconds(35f);
            Pool.SpawnGold();
            yield return new WaitForSeconds(5);
            Pool.SpawnBinary();
        }
        yield return null;
    }

    public void GotoMainMaenu()
    {
        SceneManager.LoadScene(0);
    }

}





