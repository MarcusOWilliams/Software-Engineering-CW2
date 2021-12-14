using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class game_UI_Controller : MonoBehaviour
{
    // Obtain reference to the canvas and game state objects
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameStateObject;
    [SerializeField] GameObject homeMenuButton;
    [SerializeField] GameObject gameoverRestartButton;
    public GameObject PauseScreen;
    public GameObject PauseButton;

    public pipe_Generation pG;
    public coins_Controller cC;
    public obstacle_Controller oC;



    // Update is called once per frame
    void Update()
    {
        // Obtain the state of the game
        string game_State = gameStateObject.GetComponent<game_state_controller>().game_State;

        // If the state of the game is "game over" then display the game over UI overlay
        if (game_State == "game_over")
        {
            gameOverText.SetActive(true);
            homeMenuButton.SetActive(true);
            gameoverRestartButton.SetActive(true);
            //Debug.Log("gameover");
        }
        // If the state of the game is not game over, then don't display the game over overlay.
        else
        {
            gameOverText.SetActive(false);
            homeMenuButton.SetActive(false);
            gameoverRestartButton.SetActive(false);
        }
    }

    //return to the main menu if the home button is pressed on the game over screen
    public void OnHomeButtonClicked()
    {
        Debug.Log("home button clicked");
        SceneManager.LoadScene("MenuScene");
    }

    //pause the game when the player presses the pause button
    public void OnPauseButtonClicked()
    {
        if (gameStateObject.GetComponent<game_state_controller>().game_State == "play")
        {
            gameStateObject.GetComponent<game_state_controller>().game_State = "pause";
            PauseScreen.SetActive(true);
            PauseButton.SetActive(false);
        }

    }

    //resume the game when the resume button is pressed on the pause menu
    public void OnResumeButtonClicked()
    {
        gameStateObject.GetComponent<game_state_controller>().game_State = "play";
        PauseScreen.SetActive(false);
        PauseButton.SetActive(true);

        //restart constant generation
        //used to wait before restarting generationafter pause
        StartCoroutine(waiter());
        
    }

    //restart the game when the restart button is pressed on the pause menu
    public void OnRestartButtonClicked()
    {
        gameStateObject.GetComponent<game_state_controller>().game_State = "play";
        PauseScreen.SetActive(false);
        PauseButton.SetActive(true);
        SceneManager.LoadScene("SampleScene");
    }
    //load the main menu when the exit button is pressed on the pause menu
    public void OnExitGameButtonClicked()
    {
        gameStateObject.GetComponent<game_state_controller>().game_State = "menu";
        PauseScreen.SetActive(false);
        PauseButton.SetActive(false);
        Debug.Log("Exit button clicked");
        SceneManager.LoadScene("MenuScene");
    }


    //wait given times before restarting generation after game resumes
    //this means coins obstacles and pipes will be generated at different times so are unlikely to all overlap
    IEnumerator waiter()
    {

        //Wait for 4 seconds
        yield return new WaitForSeconds(2);
        pG.generate_New_Pipe();

        yield return new WaitForSeconds(3);
        cC.generate_Coin();

        yield return new WaitForSeconds(1);
        oC.generate_Obstacle();
    }
}
