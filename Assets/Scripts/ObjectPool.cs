using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.GraphicsBuffer;

public class ObjectPool :MonoBehaviour, IDataPersistence
{
   public List<GameObject> poolObjects;
   public BubbleCollection collection,binaryCollection,goldCollection;
   public int spawnInterval=4;
   public int spawnCount=0;
   public GameController gc;

  


    private void Start()
    {
        poolObjects = new List<GameObject>();
        StartCoroutine(SpawnObjects());
    }

    IEnumerator  SpawnObjects()
    {

        while (gc.timer.IsRunning==true)
        {
            GameObject operationPrefab;
            operationPrefab = InstantiateBubbleFromCollection(collection);
            if (operationPrefab != null)
            {
                operationPrefab.transform.position = new Vector3(Random.Range(-5f, 5), Random.Range(5, 5));
                operationPrefab.SetActive(true);
                var Range = operationPrefab.GetComponent<Bubble>();
                Range.Speed = collection.speed;
                Range.secondRangeNumber = spawnCount;
                spawnCount++;
                
                
                if (spawnCount % 20 == 0)
                {
                    collection.speed++;
                    if (spawnInterval != 1)
                        spawnInterval--;
                }
                poolObjects.Add(operationPrefab);
                yield return new WaitForSeconds(spawnInterval);
            }
                

        }


    }

    public void SpawnGold()
    {
            GameObject operationPrefab;
            operationPrefab = InstantiateBubbleFromCollection(goldCollection);
            operationPrefab.transform.position = new Vector3(Random.Range(-5f, 5), Random.Range(5, 5));
            var Range = operationPrefab.GetComponent<Bubble>();
            Range.secondRangeNumber = spawnCount;
            poolObjects.Add(operationPrefab);
      
        
    }

    public void SpawnBinary()
    {
        
            GameObject operationPrefab;
            operationPrefab = InstantiateBubbleFromCollection(binaryCollection);
            operationPrefab.transform.position = new Vector3(Random.Range(-5f, 5), Random.Range(5, 5));
            var Range = operationPrefab.GetComponent<Bubble>();
            Range.secondRangeNumber = spawnCount;
            poolObjects.Add(operationPrefab);
    }


    public void ClearObj()
    {
            foreach (var obj in poolObjects)
            {
                Destroy(obj);
            }
            
    }

    GameObject InstantiateBubbleFromCollection(BubbleCollection collections)
    {
        if (collections != null)
        {
            Bubble bubbleInstance = collections.TakeBubble(GetRandomBubbleType());

            if (bubbleInstance != null)
            {
                return bubbleInstance.gameObject;
            }
        }
        return null;

    }

    BubblePrototype.eBubbleID GetRandomBubbleType()
    {
        //Tipo di bolla in modo randomico dalla Collection (addizione,sottrazzione ecc.)
        int randomIndex = Random.Range(0, collection.bubbles.Count);
        return collection.bubbles[randomIndex].operationID;
    }


    public void LoadData(GameData data)
    {
        this.collection.speed = data.collectionSpeed;
        this.spawnInterval = data.spawnInterval;
        this.spawnCount = data.spawnCount;
    }

    public void SaveData(ref GameData data)
    {
        data.collectionSpeed=this.collection.speed;
        data.spawnInterval=this.spawnInterval;
        data.spawnCount=this.spawnCount;
    }

}
