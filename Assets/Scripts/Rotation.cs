using UnityEngine;
using System.Collections;


public class Rotation : MonoBehaviour {

    /*[Range(-100,100)]*/
    public float Xaxis = 0;
    /*[Range(-100,100)]*/
    public float Yaxis = 0;
    /*[Range(-100,100)]*/
    public float Zaxis = 0;


    // Use this for initialization
    void Start() {

    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("collision");
        Xaxis = -Xaxis;
        Yaxis = -Yaxis;
        Zaxis = -Zaxis;
    }



    // Update is called once per frame
    void Update () {
        transform.Rotate(Xaxis * Time.deltaTime, Yaxis * Time.deltaTime, Zaxis * Time.deltaTime);
	}
}

