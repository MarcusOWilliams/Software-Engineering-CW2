using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipes_Interface : MonoBehaviour
{
    // First I establish items needed in this script. Note: public and [SerializeField] allow the paramters to be seen and changed in the Unity Editor.

    // Obtain reference to the pipe system object
    [SerializeField] GameObject pipe_System_Object;

    // True if an unattached pipe piece has been selected
    public bool isPipeSelected = false;

    // Used to keep track of the selected pipe piece
    public Queue<GameObject> selected_Pipe_Queue = new Queue<GameObject>();

    // A reference to the selected pipe piece
    public GameObject selected_pipe;

    // A reference to the game state object
    [SerializeField] GameObject gameStateObject;


    // Update is called once per frame
    void Update()
    {
        // If game over happens
        if (gameStateObject.GetComponent<game_state_controller>().game_state == "game_over")
        {
            selected_Pipe_Queue.Clear();
        }
        else
        {
            // If a pipe has just been clicked.
            if (selected_Pipe_Queue.Count != 0)
            {
                // Take that selected pipe game object from the queue. 
                selected_pipe = selected_Pipe_Queue.Dequeue();

                // Make sure the script knows a pipe is selected.
                isPipeSelected = true;

                // Send selected pipe piece to onEnter() and onRotate.
                onRotateInput(selected_pipe);
                onEnter(selected_pipe);

            }
            // Or if a pipe has been selected from before (i.e. no longer in the queue but not clicked off from), and not in pipe system.
            else if (isPipeSelected == true && selected_pipe.tag == "pipe")
            {
                // Send selected pipe piece to onEnter() and onRotate.
                onRotateInput(selected_pipe);
                onEnter(selected_pipe);
            }

            //https://answers.unity.com/questions/411793/selecting-a-game-object-with-a-mouse-click-on-it.html heavily used code for below
            // If the mouse has been clicked.
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse is down");

                // Get the details about the object clicked on.
                RaycastHit hitInfo = new RaycastHit();

                // See if the object did actually hit something (hit = true or false).
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

                // If the click was on an object, and that object had the tag "pipe":
                if (hit && hitInfo.transform.gameObject.tag == "pipe")
                {
                    // If that pipe was previously selected, de-select it, and vice versa.
                    isPipeSelected = !isPipeSelected;

                    // Queue the selected pipe up, so next frame this script has it ready to use.
                    selected_Pipe_Queue.Enqueue(hitInfo.transform.gameObject);
                    Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                }
                // Or if nothing is hit, or it wasn't a pipe:
                else
                {
                    isPipeSelected = false;
                }

            }
        }

    }


    // This function tests to see if the enter key has been pressed and then says what to do based on the results.
    void onEnter(GameObject selected_pipe)
    {
        // If the enter key has been pressed (and a piece of pipe has been selected (see where it is called from)):
        if (Input.GetKeyDown(KeyCode.Return) && selected_pipe.tag == "pipe")
        {
            Debug.Log("Return key was pressed.");

            // Add pipe to the pipe system
            pipe_System_Object.GetComponent<pipe_System>().add_Pipe(selected_pipe);


        }
    }

    // Check to see if pipe should be rotated given user input, and then get it to rotate itself via the pipe_Properties script.
    void onRotateInput(GameObject selected_Pipe)
    {
        // If the right arrow button was pressed.
        if (Input.GetKeyDown(KeyCode.RightArrow) && selected_pipe.tag == "pipe")
        {
            // Rotate the pipe clockwise.
            selected_pipe.GetComponent<pipe_Properties>().pipe_Rotate("right");
        }
        // If the left arrow button was pressed.
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && selected_pipe.tag == "pipe")
        {
            // Rotate the pipe anti-clockwise.
            selected_pipe.GetComponent<pipe_Properties>().pipe_Rotate("left");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && selected_pipe.tag == "pipe")
        {
            selected_pipe.GetComponent<pipe_Properties>().pipe_Rotate("up");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && selected_pipe.tag == "pipe")
        {
            selected_pipe.GetComponent<pipe_Properties>().pipe_Rotate("down");
        }
    }
}
