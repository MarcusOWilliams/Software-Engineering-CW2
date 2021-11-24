using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_System : MonoBehaviour
{
    // 
    [SerializeField] Dictionary<int, GameObject> pipe_System_Dict = new Dictionary<int, GameObject>();
    [SerializeField] List<GameObject> pipe_System_Checkpoints_List = new List<GameObject>();
    [SerializeField] GameObject starting_Pipe_Checkpoint;
    [SerializeField] Vector3 starting_Pipe_Position;
    [SerializeField] GameObject character;
    [SerializeField] string last_Pipe_End = "horizontal_right";
    

    [SerializeField] GameObject small_Straight_Pipe;
    [SerializeField] GameObject small_90Deg_Turn_Pipe;
    [SerializeField] GameObject S_Pipe;

    GameObject[] pipes_Array;

    //used to delay generation of pipes
    float pipe_Timer = 2.0f;





    private void Start()
    {
        // Set the initial position that the first pipe piece should be added at.
        starting_Pipe_Position = starting_Pipe_Checkpoint.transform.position;

        //Create an array of GameObject containing all of the possible pipes
        pipes_Array = new GameObject[2];
        pipes_Array[0] = small_Straight_Pipe;
        //pipes_Array[1] = small_90Deg_Turn_Pipe;
        pipes_Array[1] = S_Pipe;

        //Create the starting pipes and begin new pipe generation
        start_Pipe_Generation();


    }

    // Add a pipe piece to the pipe system IF the pipe piece can be added to the system.
    public void add_Pipe(GameObject pipe_Piece)
    {
        // If the pipe piece can be added to the pipe system, then add it.
        if (check_Pipe_Piece_Can_Be_Added(pipe_Piece))
        {
            // Move pipe piece to the starting pipe position for a new pipe.
            pipe_Piece.transform.position = starting_Pipe_Position;

            // Add the pipe number and the pipe game object to the pipe_System_Dict dictionary.
            pipe_System_Dict.Add(pipe_System_Dict.Count + 1, pipe_Piece);

            // Add the game object checkpoints from the respective pipe to the checkpoints list (for character movement).
            List<GameObject> pipe_Piece_Checkpoint_List = new List<GameObject>();
            pipe_Piece_Checkpoint_List = pipe_Piece.GetComponent<pipe_Properties>().checkpoint_List;

            // Create a list of the checkpoints positions from the pipe piece's checkpoint list.
            List<Vector3> pipe_Piece_Checkpoint_Vecs_List = new List<Vector3>();
            for (int i = 0; i < pipe_Piece_Checkpoint_List.Count; i++)
            {
                // *** NOTE: May remove the line below in future. It adds the checkpoint game objects to the pipe systems public list (for potential use in identifying pipe overlaps).
                pipe_System_Checkpoints_List.Add(pipe_Piece_Checkpoint_List[i]);

                // Add the checkpoint positions from the pipe to the pipe systems list.
                pipe_Piece_Checkpoint_Vecs_List.Add(pipe_Piece_Checkpoint_List[i].transform.position);

                // Add the checkpoint positions to the character's movement queue, so it will start mpving towards each position sequentially.
                character.GetComponent<character_controller>().movement_Queue.Enqueue(pipe_Piece_Checkpoint_List[i].transform.position);
            }

            // Set the new starting pipe position based on the new end of the pipe system
            starting_Pipe_Position = pipe_Piece_Checkpoint_Vecs_List[pipe_Piece_Checkpoint_Vecs_List.Count - 1];

            // Record and set the new direction of the end of the pipe system to check if future pipe piece may be added onto it.
            last_Pipe_End = pipe_Piece.GetComponent<pipe_Properties>().pipe_end;

            // Change tag of pipe to "attached_pipe" for the Pipes_Interface script reference.
            pipe_Piece.tag = "attached_pipe";
        }

    }

    // Check that the pipe piece may be added to the system given its rotation.
    private bool check_Pipe_Piece_Can_Be_Added(GameObject pipe_Piece)
    {
        if (pipe_Piece.GetComponent<pipe_Properties>().pipe_start == "horizontal_left" && last_Pipe_End == "horizontal_right")
        {
            return true;
        }
        else if (pipe_Piece.GetComponent<pipe_Properties>().pipe_start == "horizontal_right" && last_Pipe_End == "horizontal_left")
        {
            return true;
        }
        else if (pipe_Piece.GetComponent<pipe_Properties>().pipe_start == "vertical_up" && last_Pipe_End == "vertical_down")
        {
            return true;
        }
        else if (pipe_Piece.GetComponent<pipe_Properties>().pipe_start == "vertical_down" && last_Pipe_End == "vertical_up")
        {
            return true;
        }
        return false;
    }

    //generates 6 random pipe pieces with set positions to act ass the intial pipes
    //calls the generate_pipe function to start pipe generation
    private void start_Pipe_Generation()
    {
        Vector3 centre_Position = new Vector3(0.0f, 3.0f, 10.0f);

        Instantiate(pipes_Array[Random.Range(0, pipes_Array.Length)], centre_Position, Quaternion.identity);

        Instantiate(pipes_Array[Random.Range(0, pipes_Array.Length)], centre_Position + Vector3.up*3+Vector3.right*3, Quaternion.identity);

        Instantiate(pipes_Array[Random.Range(0, pipes_Array.Length)], centre_Position +  Vector3.up * 2 + Vector3.left * 3, Quaternion.identity);

        Instantiate(pipes_Array[Random.Range(0, pipes_Array.Length)], centre_Position + Vector3.down * 2 + Vector3.right * 4 + Vector3.forward * 2, Quaternion.identity);

        Instantiate(pipes_Array[Random.Range(0, pipes_Array.Length)], centre_Position + Vector3.forward * -2 + Vector3.down * 1 + Vector3.right*6 , Quaternion.identity);

        Instantiate(pipes_Array[Random.Range(0, pipes_Array.Length)], centre_Position + Vector3.left * 6 + Vector3.forward * -2+ Vector3.up*2, Quaternion.identity);

        //starts generating new pipes after 2 seconds
        Invoke("generate_New_Pipe", pipe_Timer);
    }

    //generates new pipes infront of the screen view
    private void generate_New_Pipe()
    {
        //selects a random pipe object from the array
        GameObject pipe_Selection = pipes_Array[Random.Range(0, pipes_Array.Length)];

        //creates a random position for the pipe based on the pipe locator (a child of the camera object)
        Vector3 x_pos = Vector3.right * Random.Range(-1, 1);
        Vector3 y_pos = Vector3.up * Random.Range(-3 , 3);
        Vector3 z_pos = Vector3.forward * Random.Range(-3, 3);
        Vector3 pipe_Location = GameObject.Find("pipe_Locator").transform.position + x_pos + y_pos + z_pos;
        
        //Instantiates the pipe object at the given position, keeping the rotation the same
        Instantiate(pipe_Selection, pipe_Location, Quaternion.identity);
        Debug.Log(pipe_Selection.name + "generated");

        //waits a given time then generates another pipe and increases the time waited, so pipes generate slower over time
        pipe_Timer += pipe_Timer * 0.1f;
        Invoke("generate_New_Pipe", pipe_Timer);
    }



}
