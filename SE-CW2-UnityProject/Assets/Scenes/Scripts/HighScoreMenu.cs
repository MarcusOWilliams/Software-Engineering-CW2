using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScoreMenu : MonoBehaviour
{
    public Text HighScore;
    public int HighScoreValue;
    void Start()
    {
        HighScoreValue = 0;
        HighScore.text =  $"HighScore: {HighScoreValue.ToString("0")}";
    }

}
