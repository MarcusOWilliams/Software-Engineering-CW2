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
        //Update the coin count text
        currentCoins.text = $"Total Coins: {menu_UI_Controller.saved_coin_count.ToString()}";
    }

    //called when the player clicks on the corresponding shop item
    public void BuyScoreBonus()
    {

        //if they already own the item they cannot buy it again until it is used
        if (score.scoreBonus)
        {
            StartCoroutine(popupText("You Already Have This Item Active!"));
        }

        else
        {
            //check if they have enough coins
            if (menu_UI_Controller.saved_coin_count >= 10)
            {

                //update the Boolean in the score class
                score.scoreBonus = true;


                StartCoroutine(popupText("Item Purchased!"));

                //remove coins from the balance
                menu_UI_Controller.saved_coin_count -= 10;

                //Update the coin count text
                currentCoins.text = $"Total Coins: {menu_UI_Controller.saved_coin_count.ToString()}";
            }
            else
            {
                StartCoroutine(popupText("You do not have enough coins"));
            }
            
        }
    }

    //called when the player clicks on the corresponding shop item
    public void BuyScoreMultiplier()
    {
        //if they already own the item they cannot buy it again until it is used
        if (score.scoreMulti)
        {
            StartCoroutine(popupText("You Already Have This Item Active!"));
        }

        else
        {
            //check if they have enough coins
            if (menu_UI_Controller.saved_coin_count >= 30)
            {
                //update the Boolean in the score class
                score.scoreMulti = true;

               
                StartCoroutine(popupText("Item Purchased!"));

                //remove coins from the balance
                menu_UI_Controller.saved_coin_count -= 30;

                //Update the coin count text
                currentCoins.text = $"Total Coins: {menu_UI_Controller.saved_coin_count.ToString()}";
            }
            else
            {
                StartCoroutine(popupText("You do not have enough coins"));
            }

        }
    }

    //show desired popup text for 1.5 seconds
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
