using UnityEngine;
using System.Collections;

public class MyCollision : MonoBehaviour {


    void OnCollisionEnter(Collision col)
    {
        transform.position = new Vector3(30, -1, -15);

       
    }
}
