using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    [SerializeField] Transform character;
    [SerializeField] Text scoreText;
    float score_Value;
    float total_Score;
    public static int number_Of_Coins;
    private void Start()
    {
        score_Value = 0;
        number_Of_Coins = 0;
    }
    // Update is called once per frame
    void Update()
    {
        //update the score to the furthest distance travelled by the character
        //score will not decrease if moving backwards
        score_Value = Mathf.Max(score_Value, character.position.x);

        //add the bonus from any coins collected
        total_Score = score_Value + (number_Of_Coins * 50);

        //update the score text
        scoreText.text = $"Score: {total_Score.ToString("0")}";
    }


}
