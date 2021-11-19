using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_controller : MonoBehaviour
{
    // First I establish items needed in this script. Note: public and [SerializeField] allow the paramters to be seen and changed in the Unity Editor.
    public float character_speed = 0.002f;
    [SerializeField] GameObject main_Camera;
    [SerializeField] GameObject character;
    [SerializeField] GameObject gameStateObject;
    [SerializeField] GameObject starting_Checkpoint;
    public bool isRunning;
    public bool isGameOver = false;
    public Vector3 target;
    public float x_Factor = 0f;
    public float y_Factor = 0f;
    public Queue<Vector3> movement_Queue = new Queue< Vector3 > ();

    private void Start()
    {
        target = starting_Checkpoint.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 char_Pos = character.transform.position;

        // Code below fixes a bug where the character over/under shoots the target and gets stuck.
        if (Mathf.Abs(Mathf.Abs(char_Pos.x) - Mathf.Abs(target.x)) < 0.01f && Mathf.Abs(Mathf.Abs(char_Pos.y) - Mathf.Abs(target.y)) < 0.01f)
        {
            character.transform.position = target;
            char_Pos = target;
            //Debug.Log("The character is close enough to the target to stop moving.");
            isRunning = false;
        }
        //if the character is not at the target the bool for the animation script is true
        else
        {
            isRunning = true;
        }
        // Code below moves the character towards the target position if it is not at the position already.
        if (char_Pos != target){
            // These factors dictate the direction the character will move.
            x_Factor = x_Factor_Set(x_Factor);
            y_Factor = y_Factor_Set(y_Factor);
            // This Vector3 value is how much to add to the x, y and z directions in this frame. Time.deltaTime is used to smooth the process for computers with lag.
            //Vector3 movement_Increment = new Vector3(x_Factor * character_speed * Time.deltaTime, y_Factor * character_speed * Time.deltaTime, 0f);
            // We then set the character to a new position this frame.
            //character.transform.position = char_Pos + movement_Increment;

            //https://www.codegrepper.com/code-examples/csharp/unity+how+to+move+a+gameobject+towards+another+gameobject code below used heavily from here

            // Calculate direction vector.
            Vector3 direction = character.transform.position - target;

            // Normalize resultant vector to unit Vector.
            direction = -direction.normalized;

            // Move in the direction of the direction vector every frame.
            character.transform.position += direction * Time.deltaTime * character_speed;


            // If the character is at the current target, but has more movement queued up from the next pipe, or current pipe with one or more bends in it.
        } else if (char_Pos == target && movement_Queue.Count != 0)
        {
            // Target is set by adding the movement vector from the queue to the current character position.
            //target = char_Pos + movement_Queue.Dequeue();
            target = movement_Queue.Dequeue();
            Debug.Log("Dequeue " + target);
        }

    }

    // If the  character goes off screen, we will change the game_state to "game_over."
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        gameStateObject.GetComponent<game_state_controller>().game_state = "game_over";
        isGameOver = true;
    }

    // This function determines which direction the character should be moving in.
    private float x_Factor_Set(float x_Factor)
    {
        if (character.transform.position.x != target.x)
        {
            if (target.x - character.transform.position.x > 0)
            {
                x_Factor = 1f;
            }
            else
            {
                x_Factor = -1f;
            }
        }
        else {
                x_Factor = 0;
            }
        return x_Factor;
    }

    // This function determines which direction the character should be moving in.
    private float y_Factor_Set(float y_Factor)
    {
        if (character.transform.position.y != target.y)
        {
            if (target.y - character.transform.position.y > 0)
            {
                y_Factor = 1f;
            }
            else
            {
                y_Factor = -1f;
            }
        }
        else
        {
            y_Factor = 0;
        }

        return y_Factor;
    }
}
