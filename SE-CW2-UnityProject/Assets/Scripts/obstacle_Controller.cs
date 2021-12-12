using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_Controller : MonoBehaviour
{
    [SerializeField] GameObject gameStateObject;

    [SerializeField] GameObject bomb;
    [SerializeField] GameObject spike_Ball;
    [SerializeField] GameObject asteroid;

    GameObject[] obstacle_Array;

    // Start is called before the first frame update
    void Start()
    {
        //create an array of all the obstacke game objects
        obstacle_Array = new GameObject[3];
        obstacle_Array[0] = bomb;
        obstacle_Array[1] = spike_Ball;
        obstacle_Array[2] = asteroid;

        //start obsatcle generation
        //after 1 second to aviod offset obstacle and coin generation to reduce overlapping
        Invoke("generate_Obstacle", 1f);
    }


    //generates a random obstacle infront of camera view
    public void generate_Obstacle()
    {
        //select a random obstacle
        GameObject obstacle = obstacle_Array[Random.Range(0, obstacle_Array.Length)];

        //select a random y-axis position
        float y_pos = Random.Range(-1, 5);

        Vector3 obstacle_Location = new Vector3(GameObject.Find("pipe_Locator").transform.position.x, y_pos, 0f);

        //generate the obatacle while the game is still going at 6 second intervals
        Instantiate(obstacle, obstacle_Location, Quaternion.identity);
        string game_state = gameStateObject.GetComponent<game_state_controller>().game_State;
        if (game_state == "play")
        {
            Invoke("generate_Obstacle", 6f);
        }
    }
}