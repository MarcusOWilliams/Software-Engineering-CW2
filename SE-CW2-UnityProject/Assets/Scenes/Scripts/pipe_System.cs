using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_System : MonoBehaviour
{
    [SerializeField] Dictionary<int, GameObject> pipe_System_Dict = new Dictionary<int, GameObject>();
    [SerializeField] List<Vector3> pipe_System_Checkpoints_List = new List<Vector3>();
    [SerializeField] GameObject starting_Pipe_Checkpoint;
    [SerializeField] Vector3 starting_Pipe_Position;
    [SerializeField] GameObject character;
    [SerializeField] string last_Pipe_End = "horizontal_right";

    private void Start()
    {
        starting_Pipe_Position = starting_Pipe_Checkpoint.transform.position;
    }

    public void add_Pipe(GameObject pipe_Piece)
    {
        if (check_Pipe_Piece_Can_Be_Added(pipe_Piece))
        {
            // Move pipe piece to the starting pipe position for a new pipe.
            pipe_Piece.transform.position = starting_Pipe_Position;

            // Add the pipe number and the pipe game object to the pipe_System_Dict dictionary.
            pipe_System_Dict.Add(pipe_System_Dict.Count + 1, pipe_Piece);

            // Add the checkpoints to the checkpoints list.
            List<GameObject> pipe_Piece_Checkpoint_List = new List<GameObject>();
            pipe_Piece_Checkpoint_List = pipe_Piece.GetComponent<pipe_Properties>().checkpoint_List;
            List<Vector3> pipe_Piece_Checkpoint_Vecs_List = new List<Vector3>();
            for (int i = 0; i < pipe_Piece_Checkpoint_List.Count; i++)
            {
                pipe_Piece_Checkpoint_Vecs_List.Add(pipe_Piece_Checkpoint_List[i].transform.position);
                character.GetComponent<character_controller>().movement_Queue.Enqueue(pipe_Piece_Checkpoint_List[i].transform.position);
            }

            starting_Pipe_Position = pipe_Piece_Checkpoint_Vecs_List[pipe_Piece_Checkpoint_Vecs_List.Count - 1];
            last_Pipe_End = pipe_Piece.GetComponent<pipe_Properties>().pipe_end;
        }

    }

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
