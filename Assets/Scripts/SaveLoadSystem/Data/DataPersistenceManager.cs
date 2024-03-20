using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] 
    private GameData gameData;
    [SerializeField]
    private MainMenu mainMenu;
    private List<IDataPersistence>dataPersistentsObjects;
    private FileDataHandler dataHandler;
    public static  DataPersistenceManager instance { get; private set; }

    public void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Trovata più di un instanza nella scena, l'ultima sarà distrutta");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
       
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded Called");
        this.dataPersistentsObjects = FindAllDataPersistenceObjects();
       
            if (mainMenu.LoadReq == true)
            {
                LoadGame();
            Debug.Log("Ho caicato il gioco dalla scena");
            }
            else
            {
                NewGame(new GameData());
            }
        
        
        
    }



    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistentsObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistentsObjects);
    }

    public void NewGame(GameData gameData)
    {
        this.gameData = gameData;
        
        Debug.LogError("Nuovi dati caricati");
    }
    public void ifPossibleLoad()
    {
        mainMenu = GameObject.FindWithTag("MainMenu").GetComponent<MainMenu>();
        var possibleload = dataHandler.Load();
        if (possibleload == null)
        {
            mainMenu.LoadButton.SetActive(false);
        }
        else
        {
            mainMenu.LoadButton.SetActive(true);
        }
    }
    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if(this.gameData == null)
        {
            Debug.Log("No file to Load");
            NewGame(new GameData());
        }
        Debug.Log("Ho caricato il gioco da LOAD game");
        foreach (IDataPersistence dataPersistenceObj in dataPersistentsObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistentsObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        dataHandler.Save(gameData);
    }

}
