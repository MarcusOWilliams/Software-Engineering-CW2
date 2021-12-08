using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_UI_Controller : MonoBehaviour
{

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }

}
