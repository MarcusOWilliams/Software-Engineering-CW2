using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    [SerializeField] GameObject gameStateObject;
    [SerializeField] Transform character;
    [SerializeField] Text scoreText;

    float score_Value;
    float total_Score;
    public static int number_Of_Coins;
    float bonus;

    bool addMulti;

    public static bool scoreBonus;
    public static bool scoreMulti;

    private void Start()
    {
        score_Value = 0;
        number_Of_Coins = 0;

        if (scoreMulti)
        {
            addMulti = true;
            scoreMulti = false;
        }
        else
        {
            addMulti = false;
        }

        //add 100 ponits if the player has bought the score bonus
        if (scoreBonus)
        {
            bonus = 100;
            scoreBonus = false;
        }


    }
    // Update is called once per frame
    void Update()
    {

        //update the score to the furthest distance travelled by the character
        //score will not decrease if moving backwards
        score_Value = Mathf.Max(score_Value, character.position.x);


        //add the bonus from any coins collected
        total_Score = score_Value + (number_Of_Coins * 50) + bonus;


        //double score if the player has the score multiplier
        if (addMulti)
        {
            total_Score *= 2;
        }

        if (gameStateObject.GetComponent<game_state_controller>().game_State == "play")
        {

            //update the score text
            scoreText.text = $"Score: {total_Score.ToString("0")}";
        }

        else
        {
            int HS = menu_UI_Controller.highscore;
            if ((int) total_Score > HS)
            { 
                menu_UI_Controller.highscore = (int) total_Score+1;
                
            }
            
        }

    }


}
