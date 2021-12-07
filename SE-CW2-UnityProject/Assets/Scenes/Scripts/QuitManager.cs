using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void Exit()
    {
        Application.Quit();
    }

    // Update is called once per frame

}
