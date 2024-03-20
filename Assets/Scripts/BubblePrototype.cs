using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Bubble Porototype", menuName ="Create Bubble Prototype")]
public class BubblePrototype : ScriptableObject
{
  public enum eBubbleID
    {
        Addiction,
        Subtraction,
        Division,
        Multiplication
    }

    public eBubbleID operationID;
    public GameObject PrefabObject;
    public GameObject BinaryPrefab;
    public GameObject GoldPrefab;
}
