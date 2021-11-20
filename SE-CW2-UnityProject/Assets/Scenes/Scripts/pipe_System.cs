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

    // Set the initial position that the first pipe piece should be added at.
    private void Start()
    {
        starting_Pipe_Position = starting_Pipe_Checkpoint.transform.position;
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
}
