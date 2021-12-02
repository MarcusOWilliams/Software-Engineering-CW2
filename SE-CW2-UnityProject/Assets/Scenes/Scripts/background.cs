using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    //public Transform bgo;//background original
    [SerializeField] GameObject cameraTriggerCollider;
    [SerializeField] GameObject gameBackground;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject collideWithBackground;
    void Start()
    {

        backg();

    }

    void backg()
    {
        //IEnumerator
        //yield return new WaitForSeconds(1.0f);

        //Instantiate(bgo, new Vector3(5f, 3f, 15f), Quaternion.Euler(-270, -180, 0));
        //Instantiate(bgo, new Vector3(30f, 3f, 15f), Quaternion.Euler(-270, -180, 0));
        //Instantiate(bgo, new Vector3(55f, 3f, 15f), Quaternion.Euler(-270, -180, 0));
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        Debug.Log("cam triggered");
        Vector3 background_Pos = gameObject.transform.position;
        GameObject newGamebackground = Instantiate(gameBackground, new Vector3(background_Pos.x + 99f, background_Pos.y, background_Pos.z), transform.rotation);
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
        

    }

}
