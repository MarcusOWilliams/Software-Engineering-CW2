using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public Transform bgo;
    void Start()
    {
        Instantiate(bgo, new Vector3(0, 3f, 5f), Quaternion.Euler(-270,-180,0));

    }
    

}
