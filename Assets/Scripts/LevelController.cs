using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public Valutation valutation;
    private Rigidbody2D rb;
    public GameController gc;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartGame()
    {
        valutation= gameObject.GetComponent<Valutation>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null && gc.state == GameController.eState.Onplay)
            valutation.malusPoint();
        var audio = GetComponent<AudioSource>();
        if(gc.state != GameController.eState.OnGameOver)
        audio.Play();
    }



}
    
   