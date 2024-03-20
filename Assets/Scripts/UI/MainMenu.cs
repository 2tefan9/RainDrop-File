
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{
    [SerializeField]
    private GameObject continueButton;
    [SerializeField]
    private GameObject dataPersistenceManager;
    public GameObject LoadButton;
    [SerializeField]
    private GameObject istruction;
    [SerializeField]
    private GameObject mainMenu;
    public bool LoadReq=false;
    private void Start()
    {
        dataPersistenceManager = GameObject.FindWithTag("DataManager");
        if (dataPersistenceManager != null)
        {

            dataPersistenceManager.GetComponent<DataPersistenceManager>().ifPossibleLoad();

        }
        else
        {
            // Emetti un messaggio di avviso se l'oggetto non è stato trovato
            Debug.LogWarning("Oggetto con tag 'dataManager' non trovato.");
        }
    }

    public void StartNewLevel()
    {
      DataPersistenceManager.instance.NewGame(new GameData());
      LoadReq = false;
      SceneManager.LoadScene(1);
    } 

    public void OnLoadRequest()
    {
        continueButton.SetActive(true);
    }

    public void ContinueGame()
    {
        LoadReq = true;
        SceneManager.LoadScene(1);
    }

    public void GoToIstruction()
    {
       mainMenu.SetActive(false);
        istruction.SetActive(true);
    }


    public void Exit() => Application.Quit();
}
