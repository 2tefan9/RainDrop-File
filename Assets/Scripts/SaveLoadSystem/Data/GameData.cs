using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int scoreCount;
    public int valutation;
    public float collectionSpeed;
    public int spawnInterval;
    public float currentTime;
    public int spawnCount;

    public GameData()
    {
        //Definisce valori di default
        this.scoreCount = 0;
        this.valutation = 6;
        this.collectionSpeed = 1;
        this.spawnInterval = 4;
        this.currentTime = 0;
        this.spawnCount = 0;
    }

}

