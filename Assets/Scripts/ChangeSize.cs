using UnityEngine;
using System.Collections;



public class ChangeSize : MonoBehaviour {



    public Vector3 newSize = Vector3.zero;
    public float speed = 0f;
    public bool changeSize = true;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (changeSize)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, newSize, speed * Time.deltaTime);
        }
    }
}
