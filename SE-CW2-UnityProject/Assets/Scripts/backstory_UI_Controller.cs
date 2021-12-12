using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backstory_UI_Controller : MonoBehaviour
{

    // OnExitButtonClicked is linked to the back button of the scene which loads the main menu scene
    public void OnExitButtonClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
