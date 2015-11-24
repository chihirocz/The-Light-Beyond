using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour
{

    public Vector3 point = Vector3.zero;
    public Vector3 axis = Vector3.zero;
    public float angle = 0f;

    public bool rotateAround = true;

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (rotateAround)
        {
            transform.RotateAround(point, axis, angle * Time.deltaTime);
        }
    }
}