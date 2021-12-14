using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{

    //saves a given coin count and high score from the menu_UI_Controller
    public static void SaveGameData(int coinCount, int highScoreCount)
    {
        try
        {
            PlayerPrefs.SetInt("SavedCoinCount", coinCount);
            PlayerPrefs.SetInt("SavedHighScore", highScoreCount);

            PlayerPrefs.Save();
        }
        catch
        {
            Debug.Log("There was an error saving the game data");
        }
        

    }

    //loads the coin count to the menu
    public static int LoadCoinData()
    {
        try { 
            int savedCoinCount = PlayerPrefs.GetInt("SavedCoinCount");
            return savedCoinCount;
        }

        catch
        {
            Debug.Log("No saved coin count found");
            return 0;
        }
    }

    //loads the high score to the menu
    public static int LoadHighScoreData()
    {
        try 
        {
            int savedHighScore = PlayerPrefs.GetInt("SavedHighScore");
            return savedHighScore;
        }

        catch
        {
            Debug.Log("No saved highscore found");
            return 0;
        }
    }
}
