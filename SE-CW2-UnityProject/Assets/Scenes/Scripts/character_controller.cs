using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_controller : MonoBehaviour
{
    // First I establish items needed in this script. Note: public and [SerializeField] allow the paramters to be seen and changed in the Unity Editor.

    // Alter this to change the character's speed throught the pipe system.
    public float character_speed = 0.002f;

    // Referencing the camera, character, gamestate and starting checkpoint objects for use in the code.
    [SerializeField] GameObject main_Camera;
    [SerializeField] GameObject character;
    [SerializeField] GameObject gameStateObject;
    [SerializeField] GameObject starting_Checkpoint;

    // When isRunning == true, the character should be running.
    public bool isRunning;

    // When isGameOver == true, the game state should be changed to game over (for animation)
    public bool isGameOver = false;

    // This is the position that the character is moving towards and stops at when it reaches.
    public Vector3 target;

    // This is the queue of the positions that the character should be moving towards.
    public Queue<Vector3> movement_Queue = new Queue<Vector3>();

    // Set the target to be the end position of the default starting pipe.
    private void Start()
    {
        target = starting_Checkpoint.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        // Save the character position as char_Pos
        Vector3 char_Pos = character.transform.position;

        // Code below fixes a bug where the character over/under shoots the target and gets stuck.
        // If the character is within 0.01f horizontal and vertical distance to the target.
        if (Mathf.Abs(Mathf.Abs(char_Pos.x) - Mathf.Abs(target.x)) < 0.01f && Mathf.Abs(Mathf.Abs(char_Pos.y) - Mathf.Abs(target.y)) < 0.01f)
        {
            // Move the character to the target position.
            character.transform.position = target;

            // Set the character position variable to the target (and now character) position.
            char_Pos = target;

            // Stop the character from running.
            isRunning = false;
        }

        //if the character is not at the target.
        else
        {
            // Keep the character running.
            isRunning = true;
        }
        // Code below moves the character towards the target position if it is not at the position already.
        if (char_Pos != target)
        {
            //https://www.codegrepper.com/code-examples/csharp/unity+how+to+move+a+gameobject+towards+another+gameobject: code below used heavily from this site.

            // Calculate direction vector.
            Vector3 direction = character.transform.position - target;

            // Normalize resultant vector to unit Vector.
            direction = -direction.normalized;

            // Move in the direction of the direction vector every frame.
            character.transform.position += direction * Time.deltaTime * character_speed;


            
        }
        // If the character is at the current target, but has more movement queued up from the next pipe, or current pipe with one or more bends in it.
        else if (char_Pos == target && movement_Queue.Count != 0)
        {
            // Target is set by adding the movement vector from the queue to the current character position.
            target = movement_Queue.Dequeue();
        }

    }

    // If the  character goes off screen, we will change the game_state to "game_over."
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");

        // Set the new game state using the game_state_controller.
        gameStateObject.GetComponent<game_state_controller>().game_state = "game_over";

        // This bool is now false, which is used in the animation script.
        isGameOver = true;
    }

}