using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    Animator animator;




    //uses the character_controller script as CC, to access if the character should be running
    public character_Controller CC;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CC.isGameOver)
        {
            animator.SetBool("isDead", true);
            animator.SetBool("isRunning", false);
        }
        if (CC.isRunning)
        {
            animator.SetBool("isRunning", true);

            
        }
        else
        {

            animator.SetBool("isRunning", false);

        }
        
    }
}
