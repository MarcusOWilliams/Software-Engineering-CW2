using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu_UI_Controller : MonoBehaviour
{
    public static int saved_coin_count = 0;
    public static int highscore = 0;

    [SerializeField] Text coinText;
    [SerializeField] Text HS_text;

    private void Start()
    {
        coinText.text = $"Coins: {saved_coin_count.ToString()}";
        HS_text.text = $"Highscore: {highscore.ToString()}";
    }
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }

}
