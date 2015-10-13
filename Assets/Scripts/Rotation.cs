using UnityEngine;
using System.Collections;


public class Rotation : MonoBehaviour {

    /*[Range(-100,100)]*/ public float Xaxis = 0;
    /*[Range(-100,100)]*/ public float Yaxis = 0;
    /*[Range(-100,100)]*/ public float Zaxis = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Xaxis, Yaxis, Zaxis);
	}
}
