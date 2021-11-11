using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_controller : MonoBehaviour
{
    // First I establish items needed in this script. Note: public and [SerializeField] allow the paramters to be seen and changed in the Unity Editor.
    // The movement increments are set in the Unity Editor for each pipe piece. They are used to give movement positions to the character_controller.
    public Vector3 movement_Increment1;
    public Vector3 movement_Increment2;
    public Vector3 movement_Increment3;
    // The end_Point is the Vector3 value that is used to position the new pipe piece.
    public Vector3 end_Point;
    // The starting_Point is the Vector3 value that is used to position a new pipe relative to end_Point.
    public Vector3 starting_Point;

    [SerializeField] GameObject character;
    [SerializeField] GameObject pipes_Controller_Object;

    // This function adds the movement increment to the character movement's queue. It is called from pipes_controller.cs
    public void addMovementToQueue()
    {
        character.GetComponent<character_controller>().movement_Queue.Enqueue(movement_Increment1);
        character.GetComponent<character_controller>().movement_Queue.Enqueue(movement_Increment2);
        character.GetComponent<character_controller>().movement_Queue.Enqueue(movement_Increment3);
    }

    // This function finds the next starting position of a pipe after one has been added. It is called from pipes_controller.cs
    public List<Vector3> addEndPointToList()
    {
        // Get the list from pipes_controller.cs
        List<Vector3> pipe_coord_list = pipes_Controller_Object.GetComponent<pipes_controller>().pipe_coord_list;
        // If the list is empty:
        if (pipe_coord_list.Count == 0) {
            // Hard code a starting position for the first first pipe (based on posiiton of end of starting pipe).
            Vector3 end_of_starting_pipe = new Vector3(5.7f, -0.09f, 0.657f);
            // Create a new position to place next pipe - aka: newEndPoint. 
            Vector3 newEndPoint = end_Point + end_of_starting_pipe;
            // Add the new end point to the list for reference the nect time a pipe piece is added.
            pipe_coord_list.Add(newEndPoint);
        }
        // If the list isn't empty
        else
        {
            // Create a new position where the next pipe should be placed and added it to the list.
            Vector3 newEndPoint = pipe_coord_list[pipe_coord_list.Count - 1] + end_Point;
            pipe_coord_list.Add(newEndPoint);
        }
        // Return the list back to pipes_controller.cs (where it was called).
        return pipe_coord_list;
    }
}
