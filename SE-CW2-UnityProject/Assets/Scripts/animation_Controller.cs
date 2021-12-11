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
        animator = GetComponent<Animator>();
        rb = characterObject.GetComponent<Rigidbody>();
        position = rb.worldCenterOfMass;

    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        if (CC.isGameOver)
        {
            animator.SetBool("isDead", true);
            animator.SetBool("isRunning", false);
        }
        if (CC.isRunning)
        {
            animator.SetBool("isRunning", true);
            old_position = position;
            position = rb.worldCenterOfMass;

            if (position.y - old_position.y > 0.01f)
            {
                animator.SetBool("isMovingDown", false);
                animator.SetBool("isMovingUp", true);
            }
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
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isMovingDown", false);
            animator.SetBool("isMovingUp", false);
        }

    }
}
