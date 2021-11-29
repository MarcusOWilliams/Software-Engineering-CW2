using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public Transform bgo;//background original
   
    void Start()
    {

        backg();

    }

    void backg()
    {
        //IEnumerator
        //yield return new WaitForSeconds(1.0f);

        Instantiate(bgo, new Vector3(5f, 3f, 15f), Quaternion.Euler(-270, -180, 0));
        Instantiate(bgo, new Vector3(30f, 3f, 15f), Quaternion.Euler(-270, -180, 0));
        Instantiate(bgo, new Vector3(55f, 3f, 15f), Quaternion.Euler(-270, -180, 0));
    }
    
}
