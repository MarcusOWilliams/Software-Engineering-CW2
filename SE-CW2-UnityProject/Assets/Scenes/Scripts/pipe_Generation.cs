using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_Generation : MonoBehaviour
{
    [SerializeField] GameObject gameStateObject;

    [SerializeField] GameObject small_Straight_Pipe;
    [SerializeField] GameObject small_90Deg_Turn_Pipe;
    [SerializeField] GameObject S_Pipe;
    [SerializeField] GameObject medium_Straight_Pipe;
    [SerializeField] GameObject long_Straight_Pipe;
    [SerializeField] GameObject U_Pipe;
    [SerializeField] GameObject Z_Pipe;

    GameObject[] pipes_Array;

    //used to delay generation of pipes
    float pipe_Timer = 2.2f;
    int pipe_Number = 0;

    
    // Start is called before the first frame update
    void Start()
    {

        

        //Create an array of GameObject containing all of the possible pipes
        pipes_Array = new GameObject[8];
        pipes_Array[0] = small_Straight_Pipe;
        pipes_Array[1] = small_90Deg_Turn_Pipe;
        pipes_Array[2] = S_Pipe;
        pipes_Array[3] = medium_Straight_Pipe;
        pipes_Array[4] = long_Straight_Pipe;
        pipes_Array[5] = U_Pipe;
        pipes_Array[6] = Z_Pipe;
        pipes_Array[7] = small_90Deg_Turn_Pipe;
        //Create the starting pipes and begin new pipe generation
        start_Pipe_Generation();
    }

    //generates 6 random pipe pieces with set positions to act ass the intial pipes
    //calls the generate_pipe function to start pipe generation
    private void start_Pipe_Generation()
    {
        Vector3 centre_Position = new Vector3(0.0f, 3.0f, 10.0f);

        Instantiate(pipes_Array[Random.Range(0, pipes_Array.Length)], centre_Position, Quaternion.identity);

        Instantiate(pipes_Array[Random.Range(0, pipes_Array.Length)], centre_Position + Vector3.up * 3 + Vector3.right * 3, Quaternion.identity);

        Instantiate(pipes_Array[Random.Range(0, pipes_Array.Length)], centre_Position + Vector3.up * 2 + Vector3.left * 3, Quaternion.identity);

        Instantiate(pipes_Array[Random.Range(0, pipes_Array.Length)], centre_Position + Vector3.down * 2 + Vector3.right * 4 + Vector3.forward * 2, Quaternion.identity);

        Instantiate(pipes_Array[Random.Range(0, pipes_Array.Length)], centre_Position + Vector3.forward * -2 + Vector3.down * 1 + Vector3.right * 6, Quaternion.identity);

        Instantiate(pipes_Array[Random.Range(0, pipes_Array.Length)], centre_Position + Vector3.left * 6 + Vector3.forward * -2 + Vector3.up * 2, Quaternion.identity);

        //starts generating new pipes after 2 seconds
        Invoke("generate_New_Pipe", 1);
    }

    //generates new pipes infront of the screen view
    private void generate_New_Pipe()
    {
        pipe_Number++;

        //selects a random pipe object from the array
        GameObject pipe_Selection = pipes_Array[Random.Range(0, pipes_Array.Length)];

        //creates a random position for the pipe based on the pipe locator (a child of the camera object)
        //the possible positions alternate between top and bottom half of the screen to help the spreading out of pipes

        Vector3 y_pos;

        if (pipe_Number % 2 == 0)
        {
            y_pos = Vector3.up * Random.Range(3, 7);
        }
        else
        {
            y_pos = Vector3.up * Random.Range(-4, 2);
        }
        Vector3 pipe_Location = GameObject.Find("pipe_Locator").transform.position + y_pos;

        //Instantiates the pipe object at the given position, keeping the rotation the same
        Instantiate(pipe_Selection, pipe_Location, Quaternion.identity);
        Debug.Log(pipe_Selection.name + "generated");
      
        string game_state = gameStateObject.GetComponent<game_state_controller>().game_state;
        if (game_state == "play")
        {
            //waits a given time then generates another pipe
            Invoke("generate_New_Pipe", pipe_Timer);
        }
       
    }
}
