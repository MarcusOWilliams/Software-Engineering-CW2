using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipes_controller : MonoBehaviour
{
    // First I establish items needed in this script. Note: public and [SerializeField] allow the paramters to be seen and changed in the Unity Editor.
    [SerializeField] GameObject pipe_System_Object;
    public bool isPipeSelected = false;
    public Queue<GameObject> selected_Pipe_Queue = new Queue<GameObject>();
    public GameObject selected_pipe;
    public List<Vector3> pipe_coord_list = new List<Vector3>();

    // Update is called once per frame
    void Update()
    {
        // If a pipe has just been clicked
        if (selected_Pipe_Queue.Count != 0)
        {
            // Take that selected pipe game object from the queue and send it to onEnter().
            selected_pipe = selected_Pipe_Queue.Dequeue();
            isPipeSelected = true; // Make sure the script knows a pipe is selected.
            onRotateInput(selected_pipe);
            onEnter(selected_pipe);
            
        } 
        // Or if a pipe has been selected from before (i.e. no longer in the queue but not clicked off from).
        else if (isPipeSelected == true)
        {
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


    // This function tests to see if the enter key has been pressed and then says what to do based on the results.
    void onEnter(GameObject selected_pipe)
    {
        // If the enter key has been pressed (and a piece of pipe has been selected (see where it is called from)):
        if (Input.GetKeyDown(KeyCode.Return) && selected_pipe.tag == "pipe")
        {
            Debug.Log("Return key was pressed.");
            // Add the movement required by the character to follow this pipe to the respective queue, via pipe_controller.cs
            //selected_pipe.GetComponent<pipe_controller>().addMovementToQueue();

            // Add pipe to the pipe system
            pipe_System_Object.GetComponent<pipe_System>().add_Pipe(selected_pipe);



            /*
            // If this is the first piece to be added:
            if (pipe_coord_list.Count == 0)
            {
                // Hard code the initial position of the first pipe piece.
                Vector3 starting_Point = selected_pipe.GetComponent<pipe_controller>().starting_Point;
                selected_pipe.transform.position = new Vector3(5.7f, -0.09f, 0.657f) + starting_Point;
            }
            // If previous pieces have been added:
            else
            {
                Debug.Log(pipe_coord_list.Count);
                // Get the starting point of this pipe piece.
                Vector3 starting_Point = selected_pipe.GetComponent<pipe_controller>().starting_Point;
                // Position the pipe to the end of the last pipe.
                selected_pipe.transform.position = pipe_coord_list[pipe_coord_list.Count - 1] + starting_Point;
            }
            // Add the new starting position of the next pipe piece to the list via the pipe_controller.cs script.
            pipe_coord_list = selected_pipe.GetComponent<pipe_controller>().addEndPointToList();
            // Change the tag name of the pipe piece so it can no longer be selected.
            selected_pipe.tag = "old_pipe";
            */

        }
    }

    void onRotateInput(GameObject selected_Pipe)
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && selected_pipe.tag == "pipe")
        {
            selected_pipe.GetComponent<pipe_Properties>().pipe_Rotate("right");

        } else if (Input.GetKeyDown(KeyCode.LeftArrow) && selected_pipe.tag == "pipe")
        {
            pipe_Properties pipe_Properties = selected_pipe.GetComponent<pipe_Properties>();
            pipe_Properties.pipe_Rotate("left");
        }
    }
}
