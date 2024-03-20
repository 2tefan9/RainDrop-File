using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BubblePrototype;
[CreateAssetMenu(fileName ="NewBubbleCollection", menuName ="Create Bubble Collection")]
public class BubbleCollection : ScriptableObject
{
    public List<BubblePrototype> bubbles = new List<BubblePrototype>();
    public int Base;
        public float speed;
    private GameObject newObjBubble;
    public Bubble TakeBubble(BubblePrototype.eBubbleID type)
    {
        List<BubblePrototype> possiblesBubble = new List<BubblePrototype>();
        for(int i = 0; i < bubbles.Count; i++)
        {
            if (bubbles[i].operationID == type)
            {
                possiblesBubble.Add(bubbles[i]);
            }

        }
        if(possiblesBubble.Count == 0)
        {
            Debug.LogError("Nothing bubbles type: " + type);
        }

        BubblePrototype prototype = possiblesBubble[Random.Range(0, possiblesBubble.Count)];
        switch (Base)
        {

            case 10: newObjBubble = GameObject.Instantiate(prototype.PrefabObject); break;
            case 2: newObjBubble = GameObject.Instantiate(prototype.BinaryPrefab); break;
            case 3: newObjBubble = GameObject.Instantiate(prototype.GoldPrefab); break;

        }
        
        Bubble bubble = newObjBubble.GetComponent<Bubble>();
        bubble.Base = Base;
        bubble.Speed=speed;
        bubble.SetupBubble(prototype);
        return bubble;
    }
}
