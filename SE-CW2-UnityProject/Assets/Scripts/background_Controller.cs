using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_Controller : MonoBehaviour
{
    //public Transform bgo;//background original
    [SerializeField] GameObject cameraTriggerCollider;
    [SerializeField] GameObject gameBackground;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject collideWithBackground;
    [SerializeField] GameObject gameStateObject;

    //when the character collides with the background collder, create a new roling background
    //Then destroy the onld background after 70 seconds.
    IEnumerator OnTriggerEnter(Collider other)
    {
        Debug.Log("cam triggered");
        Vector3 background_Pos = gameObject.transform.position;
        GameObject newGamebackground = Instantiate(gameBackground, new Vector3(background_Pos.x + 99f, background_Pos.y, background_Pos.z), transform.rotation);
        yield return new WaitForSeconds(70);
        while (gameStateObject.GetComponent<game_state_controller>().game_State == "pause")
        {
            yield return new WaitForSeconds(70);
        }
        Destroy(gameObject);


    }

}
