using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_Controller : MonoBehaviour
{
    // Obtain reference to the canvas and game state objects
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameStateObject;
    [SerializeField] GameObject homeMenuButton;
    public GameObject PauseScreen;
    public GameObject PauseButton;

    // Update is called once per frame
    void Update()
    {
        // Obtain the state of the game
        string game_State = gameStateObject.GetComponent<game_State_Controller>().game_State;

        // If the state of the game is "game over" then display the game over UI overlay
        if (game_State == "game_over")
        {
            gameOverText.SetActive(true);
            homeMenuButton.SetActive(true);
            //Debug.Log("gameover");
        }
        // If the state of the game is not game over, then don't display the game over overlay.
        else
        {
            gameOverText.SetActive(false);
            homeMenuButton.SetActive(false);
        }
    }

    public void OnHomeButtonClicked()
    {
        Debug.Log("home button clicked");
        SceneManager.LoadScene("MenuScene");
    }

    public void OnPauseButtonClicked()
    {
        if (gameStateObject.GetComponent<game_State_Controller>().game_State == "play")
        {
            gameStateObject.GetComponent<game_State_Controller>().game_State = "pause";
            PauseScreen.SetActive(true);
            PauseButton.SetActive(false);
        }

    }

    public void OnResumeButtonClicked()
    {
        gameStateObject.GetComponent<game_State_Controller>().game_State = "play";
        PauseScreen.SetActive(false);
        PauseButton.SetActive(true);
    }


    public void OnExitGameButtonClicked()
    {
        gameStateObject.GetComponent<game_State_Controller>().game_State = "menu";
        PauseScreen.SetActive(false);
        PauseButton.SetActive(false);
        Debug.Log("Exit button clicked");
        SceneManager.LoadScene("MenuScene");
    }
}
