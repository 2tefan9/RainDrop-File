using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bubble:MonoBehaviour
{
    public float Speed;
    public BubblePrototype.eBubbleID bubbleType;
    public Vector2 position;
    [SerializeField]
    private Animation animations;

    public int Solution { get;  set; }
    public int Base {  get; set; }  

    public int secondRangeNumber { get; set; }
    public void SetupBubble(BubblePrototype bubblesType) => bubbleType = bubblesType.operationID;
   
    void Update()
    {
        transform.Translate(Vector2.down*Speed*Time.deltaTime);
        position=transform.position;
        if (position.y<-7)
        {
            Destroy(gameObject);
        }
    }

    public void AnimationCancelling()
    {
        switch(Base)
        {
            case 10:
                //playclipanimaionedecimale
                StartCoroutine(CancellingOperation());
                break;
            case 3:
                //playanimazioneGold
                StartCoroutine(CancellingOperation());
                break;
            case 2:
                //playanimazionebinaria
                StartCoroutine(CancellingOperation());
                break;
        }
    }
    

    IEnumerator CancellingOperation()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}