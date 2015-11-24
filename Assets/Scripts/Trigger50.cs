using UnityEngine;
using System.Collections;

public class Trigger50 : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 0, 200);
        cube.transform.localScale = new Vector3(100, 100, 100);
        var c = cube.AddComponent<CubeRotation>();
        c.Xaxis = 10;
        c.Yaxis = 10;
        c.Zaxis = 10;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
