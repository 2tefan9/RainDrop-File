using System;
using System.Collections;
using TMPro;
using UnityEngine;
public class ScoreController : InputField
{
    public TMP_Text scoreText;
    public int currentValue = 0;

    private new void Start()
    {
        UpdateScoreText(currentValue);
    }

    public void UpdateScoreText(int valueScore)
    {
        if (valueScore == 250)
        {
            Color flashColor =Color.yellow;
            StartCoroutine(flashScore(flashColor));
        }
        else if(valueScore == 500)
        {
            Color flashColor = Color.green;
            StartCoroutine(flashScore(flashColor));
        }
        else
        {
            scoreText.color = Color.white;
            scoreText.fontSize = 17;
        }

        currentValue += valueScore;
        scoreText.text = Convert.ToString(currentValue);

    }

    IEnumerator flashScore(Color flashColor)
    {
            scoreText.color = flashColor;
            scoreText.fontSize = 25;
            yield return new WaitForSeconds(2);
            scoreText.color = Color.white;
            scoreText.fontSize = 17;
            yield return new WaitForSeconds(2);
    }


}
