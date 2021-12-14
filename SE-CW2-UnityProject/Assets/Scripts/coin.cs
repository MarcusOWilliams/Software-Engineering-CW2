using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField] GameObject gameStateObject;

    // Update is called once per frame
    void Update()
    {
        //while the game is playing
        if (gameStateObject.GetComponent<game_state_controller>().game_State == "play")
        {
            //spin the coin
            transform.Rotate(new Vector3(0f, 75f, 0f) * Time.deltaTime);
        }
    }
}
