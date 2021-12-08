using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    // First I establish items needed in this script. Note: public and [SerializeField] allow the paramters to be seen and changed in the Unity Editor.

    // References to the camera, and game state object.
    [SerializeField] GameObject main_Camera;
    [SerializeField] GameObject gameStateObject;


    // This float is proportional to the cameras movement speed.
    public float camera_speed = 1f;

    // Update is called once per frame
    void Update()
    {

        // First we access the game_state via the object gameStateObject, that holds the game_state string.
        string game_state = gameStateObject.GetComponent<game_state_controller>().game_State;

        // If the game_state = "play" we want the camera to move continously.
        if (game_state == "play")
        {
            main_Camera.transform.Translate(camera_speed * Time.deltaTime, 0, 0);
        }

    }

    //called once every physics update
    //speeding up camera here stops faster framerates making the camera speed up faster
    private void FixedUpdate()
    {
        //slowly increases the speed of the camera to increase game difficulty
        camera_speed = camera_speed + .0001f;
    }


}
