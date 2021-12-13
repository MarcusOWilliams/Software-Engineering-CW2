using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinShop : MonoBehaviour
{
    public bool scoreBonus;
    [SerializeField] Text PopupText;
    public void BuyScoreBonus()
    {
        if (scoreBonus)
        {
            StartCoroutine(popupText("You Already Have This Item Active!"));
        }
        else
        {
            scoreBonus = true;
            StartCoroutine(popupText("Item Purchased!"));
        }
    }
    IEnumerator popupText(string s)
    {

        PopupText.text = s;
        yield return new WaitForSeconds(1.5f);
        PopupText.text = "";

    }
}
