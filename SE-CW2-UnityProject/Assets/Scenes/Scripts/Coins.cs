using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    [SerializeField] GameObject coin;

    [SerializeField] GameObject gameStateObject;

    // Start is called before the first frame update
    void Start()
    {
        //generarte 3 intial starting coins
        starting_Coins();
        Invoke("generate_Coin", 0.1f);
    }

    //add bonus points to the score when a coin is collected
    //destroy coin object when it is collected
    public static void coinCollected(Collider coin)
    {

        //add bonus to score
        score.number_Of_Coins += 1;

        Destroy(coin.gameObject);
    }

    //generate a new coin infront of camera view at a ranom point on the y-axis
    private void generate_Coin()
    {
        float y_pos = Random.Range(-1, 5);

        Vector3 coin_Location = new Vector3(GameObject.Find("pipe_Locator").transform.position.x, y_pos, 3.25f);
        Instantiate(coin, coin_Location, Quaternion.identity);

        string game_state = gameStateObject.GetComponent<game_state_controller>().game_state;
        if (game_state == "play")
        {
            Invoke("generate_Coin", 6f);
        }
    }

    //generarte 3 intial starting coins at set locations
    private void starting_Coins()
    {
        Vector3 coin_placer = new Vector3(7, 0, 3.25f);
        Instantiate(coin, coin_placer, Quaternion.identity);
        Instantiate(coin, coin_placer + Vector3.right*5 + Vector3.up*2, Quaternion.identity);
        Instantiate(coin, coin_placer + Vector3.right * 3 + Vector3.down * 2, Quaternion.identity);
    }
}
