using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancellingAnim : MonoBehaviour
{
    [SerializeField]
    private Animation animations;

    void Start()
    {
        animations = GetComponent<Animation>();
        animations.Play();
        StartCoroutine(DeleteObj());
    }

    IEnumerator DeleteObj()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }
}
