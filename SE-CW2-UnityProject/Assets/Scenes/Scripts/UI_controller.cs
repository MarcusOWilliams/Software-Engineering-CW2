using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_controller : MonoBehaviour
{
    // Obtain reference to the canvas and game state objects
    [SerializeField] GameObject UI_Canvas;
    [SerializeField] GameObject gameStateObject;

    // Update is called once per frame
    void Update()
    {
        // Obtain the state of the game
        string game_state = gameStateObject.GetComponent<game_state_controller>().game_state;

        // If the state of the game is "game over" then display the game over UI overlay
        if (game_state == "game_over")
        {
            UI_Canvas.SetActive(true);
            Debug.Log("gameover");
        }
        // If the state of the game is not game over, then don't display the game over overlay.
        else
        {
            UI_Canvas.SetActive(false);
        }
    }
}
