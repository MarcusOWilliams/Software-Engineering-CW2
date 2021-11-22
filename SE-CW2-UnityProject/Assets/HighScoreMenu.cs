using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScoreMenu : MonoBehaviour
{
    public Text HighScore;
    void Start()
    {
        HighScore.text = 0.ToString();
    }

}
