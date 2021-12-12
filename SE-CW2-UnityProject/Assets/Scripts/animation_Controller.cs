using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_Controller : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject characterObject;

    //uses the character_controller script as CC, to access if the character should be running
    public character_controller CC;

    Rigidbody rb;
    Vector3 position;
    Vector3 old_position;
    bool goingBackwards = false;

    // Start is called before the first frame update
    void Start()
    {
        //set variable for the animation controller, character rigidbofy and get the intial position of the character
        animator = GetComponent<Animator>();
        rb = characterObject.GetComponent<Rigidbody>();
        position = rb.worldCenterOfMass;

    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        //check if the game is over, if it is stop running and trigger the death animation in the controller
        if (CC.isGameOver)
        {
            animator.SetBool("isDead", true);
            animator.SetBool("isRunning", false);
        }
        //if the character is moving towards a target, toggle the running bool in the animation controller
        if (CC.isRunning)
        {
            animator.SetBool("isRunning", true);

            //update position, to compare the difference between where the character has moved since the function was last called
            old_position = position;
            position = rb.worldCenterOfMass;

            //if the character is moving upwards
            if (position.y - old_position.y > 0.01f)
            {
                animator.SetBool("isMovingDown", false);
                animator.SetBool("isMovingUp", true);
            }
            //if the character is moving down
            else if (position.y - old_position.y < -0.01f)
            {
                animator.SetBool("isMovingUp", false);
                animator.SetBool("isMovingDown", true);

            }
            else
            {
                animator.SetBool("isMovingDown", false);
                animator.SetBool("isMovingUp", false);
            }

            //if the character is going backwards
            if (position.x - old_position.x < 0f )
            {
                if (!goingBackwards)
                {
                    transform.RotateAround(transform.position, transform.up, 180f);
                    goingBackwards = true;
                }
                
            }
            else
            {
                if (goingBackwards)
                {
                    transform.RotateAround(transform.position, transform.up, 180f);
                    goingBackwards = false;
                }

            }


        }
        //if the character is not running and the game is not over, set all animation bools to false.
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isMovingDown", false);
            animator.SetBool("isMovingUp", false);
        }

    }
}
