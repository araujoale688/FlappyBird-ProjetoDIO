using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreScript : MonoBehaviour
{
    public Text PoitScore;

    void Update()
    {
        if (GameManager.Instance.IsGameOver())
        {
            return;
        }

        PoitScore.text = GameManager.Instance.score.ToString();
    }
}