using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinShop : MonoBehaviour
{

    [SerializeField] Text PopupText;
    [SerializeField] Text currentCoins;

    private void Start()
    {
        currentCoins.text = $"TotalCoins: {menu_UI_Controller.saved_coin_count.ToString()}";
    }
    public void BuyScoreBonus()
    {
        if (score.scoreBonus)
        {
            StartCoroutine(popupText("You Already Have This Item Active!"));
        }
        else
        {
            if (menu_UI_Controller.saved_coin_count >= 10)
            {
                score.scoreBonus = true;
                StartCoroutine(popupText("Item Purchased!"));
                menu_UI_Controller.saved_coin_count -= 10;
                currentCoins.text = $"Total Coins: {menu_UI_Controller.saved_coin_count.ToString()}";
            }
            else
            {
                StartCoroutine(popupText("You do not have enough coins"));
            }
            
        }
    }

    public void BuyScoreMultiplier()
    {
        if (score.scoreMulti)
        {
            StartCoroutine(popupText("You Already Have This Item Active!"));
        }
        else
        {
            if (menu_UI_Controller.saved_coin_count >= 30)
            {
                score.scoreMulti = true;
                StartCoroutine(popupText("Item Purchased!"));
                menu_UI_Controller.saved_coin_count -= 30;
                currentCoins.text = $"Total Coins: {menu_UI_Controller.saved_coin_count.ToString()}";
            }
            else
            {
                StartCoroutine(popupText("You do not have enough coins"));
            }

        }
    }
    IEnumerator popupText(string s)
    {

        PopupText.text = s;
        yield return new WaitForSeconds(1.5f);
        PopupText.text = "";

    }


    // OnExitButtonClicked is linked to the back button of the scene which loads the main menu scene
    public void OnExitButtonClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
