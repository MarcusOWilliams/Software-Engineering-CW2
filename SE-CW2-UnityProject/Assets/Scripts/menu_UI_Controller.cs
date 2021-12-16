using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu_UI_Controller : MonoBehaviour
{
    public static int saved_coin_count = -1;
    public static int highscore;

    [SerializeField] Text coinText;
    [SerializeField] Text HS_text;


    //when the game is loaded set all the relevant text
    private void Start()
    {
        //reset resolution to 1080p so text always fits correctly
        Screen.SetResolution(1920, 1080, true);


        //if the saved highscore has not been loaded, then get it from the save files
        if (highscore < SaveGame.LoadHighScoreData())
        {
            highscore = SaveGame.LoadHighScoreData();
        }
        //if the saved coin count has not been loaded, then get it from the save files
        if (saved_coin_count<0)
        {
            saved_coin_count = SaveGame.LoadCoinData();
        }

        //update the coin and highscore text at the top of the screen
        coinText.text = $"Coins: {saved_coin_count.ToString()}";
        HS_text.text = $"Highscore: {highscore.ToString()}";
        
    }

    //Load the game cene when the start button is pressed
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //Load the controls scene when the controls button is pressed
    public void OnControlButtonClicked()
    {
        SceneManager.LoadScene("Controls");
    }

    //Exit the game when the exit button is pressed
    public void OnExitButtonClicked()
    {

        SaveGame.SaveGameData(saved_coin_count, highscore);
        Application.Quit();
    }

    //Load the backstory scene when the backstory button is pressed
    public void OnBackStoryClicked()
    {
        SceneManager.LoadScene("BackStory");
    }
    //Load the CoinShop scene when the CoinShop button is pressed
    public void OnCoinShopClicked()
    {
        SceneManager.LoadScene("CoinShop");
    }

}
