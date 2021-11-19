using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_Properties : MonoBehaviour
{
    [SerializeField] Vector3 pipe_Rotation = new Vector3(0, 0, 0);
    [SerializeField] string pipe_entry = "horizontal";
    [SerializeField] int current_Rotation = 0;
    [SerializeField] GameObject rotational_Centre;
    public string pipe_start = "horizontal_left";
    public string pipe_end = "horizontal_right";
    [SerializeField] string zero_degree_pipe_start = "h";
    [SerializeField] string ninety_degree_pipe_start = "h";
    [SerializeField] string one_eighty_degree_pipe_start = "h";
    [SerializeField] string two_seventy_degree_pipe_start = "h";
    [SerializeField] string zero_degree_pipe_end = "h";
    [SerializeField] string ninety_degree_pipe_end = "h";
    [SerializeField] string one_eighty_degree_pipe_end = "h";
    [SerializeField] string two_seventy_degree_pipe_end = "h";
    public List<GameObject> checkpoint_List = new List<GameObject>();

    private void Update()
    {
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

    //Call this function to rotate the pipe piece selected.
    public void pipe_Rotate(string direction)
    {

        // Find the next rotation value
        if (direction == "right")
        {
            gameObject.transform.RotateAround(rotational_Centre.transform.position, Vector3.forward, -90);
            Debug.Log("right");
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
            gameObject.transform.RotateAround(rotational_Centre.transform.position, Vector3.forward, 90);
            if (current_Rotation == 0)
            {
                current_Rotation = 270;
            }
            else
            {
                current_Rotation = current_Rotation - 90;
            }

        }


        //gameObject.transform.eulerAngles = new Vector3(0, 0, current_Rotation);

    }
}
