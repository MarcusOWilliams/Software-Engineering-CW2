using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_controller : MonoBehaviour
{
    [SerializeField] GameObject UI_Canvas;
    [SerializeField] GameObject gameStateObject;

    // Update is called once per frame
    void Update()
    {
        string game_state = gameStateObject.GetComponent<game_state_controller>().game_state;
        if (game_state == "game_over")
        {
            UI_Canvas.SetActive(true);
            Debug.Log("gameover");
        }
        else
        {
            UI_Canvas.SetActive(false);
        }
    }
}
