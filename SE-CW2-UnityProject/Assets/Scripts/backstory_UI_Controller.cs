using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backstory_UI_Controller : MonoBehaviour
{

    // Update is called once per frame
    public void OnExitButtonClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
