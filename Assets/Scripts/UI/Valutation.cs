using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Windows;

public class Valutation : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    private ScoreController scoreController;
    [SerializeField]
    private GameController gc;
    public TMP_Text characters;
    private char value;
    public int Grade;
    [SerializeField]
    private ObjectPool Pool;
    [SerializeField]
    private AudioSource cancelling;
    [SerializeField]
    private AudioSource goldSol;
    [SerializeField]
    private AudioSource binarySol;
    [SerializeField]
    private AudioSource gameOver;
    private Vector2 position;
    [SerializeField]
    private GameObject animPrefab;
    [SerializeField]
    private GameObject animPrefabGold;
    [SerializeField]
    private GameObject animPrefabBin;

    private void Update()
    {
        Value();
        AssignText();
    }


    public void Value()
    {
        switch (Grade)
        {
            case 6:
                value= 'A';
                characters.color = Color.green;
                break;
            case 5:
                value = 'B';
                characters.color = new Color(0.56f, 0.93f, 0.56f); ;
                break;
            case 4:
                value = 'C';
                characters.color = Color.yellow;
                break;
            case 3:
                value = 'D';
                characters.color = new Color(1.0f, 0.8f, 0.6f);
                break;
            case 2:
                value = 'E';
                characters.color = new Color(1.0f, 0.647f, 0.0f);
                break;
            case 1:
                value = 'F';
                characters.color = Color.red;
                break;

        }
    }



    public void ReserchSolution(int solution)
    {
        for (int i = Pool.poolObjects.Count - 1; i >= 0; i--)
        {
            var prefabInstance = Pool.poolObjects[i];
            if (prefabInstance != null)
            {
                var prefabScript = prefabInstance.GetComponent<Bubble>();
                var based = prefabScript.Base;
                 position = prefabInstance.transform.position;
                int prefabSolution = prefabScript.Solution;
                // Confronta con il valore di input utente
                if (prefabSolution == solution)
                {

                    prefabInstance.SetActive(false);

                    switch (based)
                    {
                        case 10:
                            cancelling.Play();
                            GameObject animPrefabObj = Instantiate(animPrefab, position, transform.rotation);
                            scoreController.UpdateScoreText(100);
                            break;
                        case 3:
                            goldSol.Play();
                            GameObject animPrefabObjG = Instantiate(animPrefabGold, position, transform.rotation);
                            scoreController.UpdateScoreText(250);
                            Pool.ClearObj();
                            break;
                        case 2:
                            binarySol.Play();
                            GameObject animPrefabObjB = Instantiate(animPrefabBin, position, transform.rotation);
                            scoreController.UpdateScoreText(500);
                            break;

                    }

                    if (Grade < 6)
                    {
                        Grade++;
                    }
                    Destroy(prefabInstance);
                }
            }


        }

    }

    public void malusPoint()
    {
        Grade--;
        if (Grade == 1)
        {
            gameOver.Play();
            gc.goToState(GameController.eState.OnGameOver);
        }
       
    }

    public void AssignText() => characters.text = Convert.ToString(value);

    public void LoadData(GameData data)
    {
        scoreController.currentValue = data.scoreCount;
        this.Grade = data.valutation;
    }

    public void SaveData(ref GameData data)
    {
        data.scoreCount = 0;
        data.scoreCount = scoreController.currentValue;
        data.valutation = this.Grade;
    }

}
