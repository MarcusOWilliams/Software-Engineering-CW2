using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_state_controller : MonoBehaviour
{
    // First I establish items needed in this script. Note: public and [SerializeField] allow the paramters to be seen and changed in the Unity Editor.
    public string game_State = "play";

    // Start is called before the first frame update
    void Start()
    {
        // For now, we will set the game_state to always be "play."
        game_State = "play";
    }

}

