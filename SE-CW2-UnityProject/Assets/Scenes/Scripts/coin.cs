using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField] GameObject gameStateObject;

    // Update is called once per frame
    void Update()
    {
        if (gameStateObject.GetComponent<game_State_Controller>().game_State == "play")
        {
            transform.Rotate(new Vector3(0f, 75f, 0f) * Time.deltaTime);
        }
    }
}
