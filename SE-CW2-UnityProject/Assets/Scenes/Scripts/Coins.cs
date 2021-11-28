using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    [SerializeField] GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("generate_Coin", 0.1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void coinCollected(Collider coin)
    {

        //add bonus to score
        score.number_Of_Coins += 1;

        Destroy(coin.gameObject);
    }

    private void generate_Coin()
    {
        float y_pos = Random.Range(-1, 5);

        Vector3 coin_Location = new Vector3(GameObject.Find("pipe_Locator").transform.position.x-5f, y_pos, 3.25f);
        Instantiate(coin, coin_Location, Quaternion.identity);
    }
}
