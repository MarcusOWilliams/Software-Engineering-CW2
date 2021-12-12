using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins_Controller : MonoBehaviour
{

    [SerializeField] GameObject coin;

    [SerializeField] GameObject gameStateObject;

    // Start is called before the first frame update
    void Start()
    {
        //generarte 3 intial starting coins
        starting_Coins();

        //start constant coin generation
        Invoke("generate_Coin", 0.1f);
    }

    //add bonus points to the score when a coin is collected
    public static void coinCollected(Collider coin)
    {

        //add bonus to score
        score.number_Of_Coins ++;

        //update total coins collected
        menu_UI_Controller.saved_coin_count++;

        //remove the coin object when the player collects it
        Destroy(coin.gameObject);
    }

    //generate a new coin infront of camera view at a random point on the y-axis
    public void generate_Coin()
    {
        //generate a ranom position along the y_axis
        float y_pos = Random.Range(-2, 6);

        //generate the location for the coin based on the pipe locator, the random y position and a set z position.
        Vector3 coin_Location = new Vector3(GameObject.Find("pipe_Locator").transform.position.x, y_pos, 3.25f);

        //create the coin object
        Instantiate(coin, coin_Location, Quaternion.identity);

        //while the game is still being played continue generate coins at a 6 second interval
        string game_state = gameStateObject.GetComponent<game_state_controller>().game_State;
        if (game_state == "play")
        {
            Invoke("generate_Coin", 6f);
        }
    }

    //generarte 3 intial starting coins at set locations
    private void starting_Coins()
    {
        //the intial coins have set positions
        Vector3 coin_placer = new Vector3(7, 0, 3.25f);
        Instantiate(coin, coin_placer, Quaternion.identity);
        Instantiate(coin, coin_placer + Vector3.right * 5 + Vector3.up * 2, Quaternion.identity);
        Instantiate(coin, coin_placer + Vector3.right * 3 + Vector3.down * 2, Quaternion.identity);
    }
}
