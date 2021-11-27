using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void coinCollected(Collider coin)
    {
        Debug.Log("Coin collected");

        //add bonus to score
        score.number_Of_Coins += 1;

        Destroy(coin.gameObject);
    }
}
