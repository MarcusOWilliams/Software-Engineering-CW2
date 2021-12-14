using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_Properties : MonoBehaviour
{

    // Display the current rotation of the pipe piece in the unity editor
    [SerializeField] int current_Rotation = 0;

    // The rotational centre is childed under the pipe_holder, and is used as a pivot point for the pipe holder to rotate around.
    [SerializeField] GameObject rotational_Centre;

    // Theses strings show where the pipe entry and ending or pointing (used to determine if a pipe piece may be added to the pipe system).
    public string pipe_start = "horizontal_left";
    public string pipe_end = "horizontal_right";

    // These strings show where the pipe entry is pointing when at one of the 4 rotations (0, 90, 180, and 270 deg)
    [SerializeField] string zero_degree_pipe_start = "horizontal_left";
    [SerializeField] string ninety_degree_pipe_start = "horizontal_left";
    [SerializeField] string one_eighty_degree_pipe_start = "horizontal_left";
    [SerializeField] string two_seventy_degree_pipe_start = "horizontal_left";

    // These strings show where the pipe ending is pointing when at one of the 4 rotations (0, 90, 180, and 270 deg)
    [SerializeField] string zero_degree_pipe_end = "horizontal_left";
    [SerializeField] string ninety_degree_pipe_end = "horizontal_left";
    [SerializeField] string one_eighty_degree_pipe_end = "horizontal_left";
    [SerializeField] string two_seventy_degree_pipe_end = "horizontal_left";

    //this bool checks if the pipe is being added in a reverse way
    public bool is_pipe_reversed;

    // This list contains the game object checkpoints childed under the pipe holder object, which are used as character movement checkpoints
    public List<GameObject> checkpoint_List = new List<GameObject>();

    // The spotlight used to highlight the pipe
    [SerializeField] GameObject pipeHighlight;

    private void Start()
    {
        pipeHighlight.SetActive(false);
    }


    private void Update()
    {
        // Update the strings which contain where the start and end of the pipe is pointing, based on the pipe's rotation.
        if (current_Rotation == 0)
        {
            pipe_start = zero_degree_pipe_start;
            pipe_end = zero_degree_pipe_end;
        }
        else if (current_Rotation == 90)
        {
            pipe_start = ninety_degree_pipe_start;
            pipe_end = ninety_degree_pipe_end;
        }
        else if (current_Rotation == 180)
        {
            pipe_start = one_eighty_degree_pipe_start;
            pipe_end = one_eighty_degree_pipe_end;
        }
        else if (current_Rotation == 270)
        {
            pipe_start = two_seventy_degree_pipe_start;
            pipe_end = two_seventy_degree_pipe_end;
        }
    }

    // Call this function to rotate the pipe piece selected.
    public void pipe_Rotate(string direction)
    {

        // Find the new rotation angle and rotate the pipe holder to reflect this
        if (direction == "right")
        {
            // Rotate the pipe holder clockwise
            gameObject.transform.RotateAround(rotational_Centre.transform.position, Vector3.forward, -90);

            // Set the value for the current rotation of the pipe
            if (current_Rotation == 270)
            {
                current_Rotation = 0;
            }
            else
            {
                current_Rotation = current_Rotation + 90;
            }

        } else if (direction == "left")
        {
            // Rotate the pipe holder anti-clockwise
            gameObject.transform.RotateAround(rotational_Centre.transform.position, Vector3.forward, 90);

            // Set the value for the current rotation of the pipe
            if (current_Rotation == 0)
            {
                current_Rotation = 270;
            }
            else
            {
                current_Rotation = current_Rotation - 90;
            }

        //allows change of entry for U shaped piped
        //changes checkpoint rendering for starting point
        }else if (direction == "up"|| direction == "down")
        {
            if (gameObject.name.Contains("U_pipe"))
            {
                List<GameObject> pipe__Checkpoint_List = new List<GameObject>();
                pipe__Checkpoint_List = gameObject.GetComponent<pipe_Properties>().checkpoint_List;

                //removes any currently highlighted entry
                foreach(GameObject checkpoint in pipe__Checkpoint_List)
                {
                    checkpoint.GetComponent<Renderer>().enabled = false;
                }


                //highlights the new entry point and reverse/unreverses the pipe direction
                if (gameObject.GetComponent<pipe_Properties>().is_pipe_reversed)
                {
                    GameObject c1 = pipe__Checkpoint_List[0];
                    c1.GetComponent<Renderer>().enabled = true;
                    gameObject.GetComponent<pipe_Properties>().is_pipe_reversed = false;
                }
                else
                {
                    GameObject c1 = pipe__Checkpoint_List[3];
                    c1.GetComponent<Renderer>().enabled = true;
                    gameObject.GetComponent<pipe_Properties>().is_pipe_reversed = true;
                }
                
            }
        }

    }
    //toggle pipe highlights
    public void turnHighlightOn()
    {
        pipeHighlight.SetActive(true);
    }

    public void turnHighlightOff()
    {
        pipeHighlight.SetActive(false);
    }
}
