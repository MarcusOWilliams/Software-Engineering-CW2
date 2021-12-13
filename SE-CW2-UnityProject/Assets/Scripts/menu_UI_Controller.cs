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

    private void Start()
    {
        if (highscore < SaveGame.LoadHighScoreData())
        {
            highscore = SaveGame.LoadHighScoreData();
        }
        if (saved_coin_count<0)
        {
            saved_coin_count = SaveGame.LoadCoinData();
        }
        coinText.text = $"Coins: {saved_coin_count.ToString()}";
        HS_text.text = $"Highscore: {highscore.ToString()}";
        
    }
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnControlButtonClicked()
    {
        SceneManager.LoadScene("Controls");
    }

    public void OnExitButtonClicked()
    {

        SaveGame.SaveGameData(saved_coin_count, highscore);
        Application.Quit();
    }

    public void OnBackStoryClicked()
    {
        SceneManager.LoadScene("BackStory");
    }
    public void OnCoinShopClicked()
    {
        SceneManager.LoadScene("CoinShop");
    }

}
