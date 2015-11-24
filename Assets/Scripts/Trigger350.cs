using UnityEngine;
using System.Collections;

public class Trigger350 : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.transform.position = new Vector3(25, 25, 525);
        cube1.transform.localScale = new Vector3(50, 50, 50);
        /*var c1 = cube1.AddComponent<RotateAround>();
        c1.point = new Vector3(0, 0, 500);
        c1.axis = new Vector3(1, 1, 1);
        c1.angle = 50;*/
        var d1 = cube1.AddComponent<MoveTowardAndBack>();
        d1.movement = new Vector3(10, 10, 10);
        d1.distance = 50;

        GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2.transform.position = new Vector3(-25, 25, 525);
        cube2.transform.localScale = new Vector3(50, 50, 50);
        /*var c2 = cube2.AddComponent<RotateAround>();
        c2.point = new Vector3(0, 0, 500);
        c2.axis = new Vector3(1, 1, 1);
        c2.angle = 50;*/
        var d2 = cube2.AddComponent<MoveTowardAndBack>();
        d2.movement = new Vector3(-10, 10, 10);
        d2.distance = 50;

        GameObject cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube3.transform.position = new Vector3(25, -25, 525);
        cube3.transform.localScale = new Vector3(50, 50, 50);
        /*var c3 = cube3.AddComponent<RotateAround>();
        c3.point = new Vector3(0, 0, 500);
        c3.axis = new Vector3(1, 1, 1);
        c3.angle = 50;*/
        var d3 = cube3.AddComponent<MoveTowardAndBack>();
        d3.movement = new Vector3(10, -10, 10);
        d3.distance = 50;

        GameObject cube4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube4.transform.position = new Vector3(-25, -25, 525);
        cube4.transform.localScale = new Vector3(50, 50, 50);
        /*var c4 = cube4.AddComponent<RotateAround>();
        c4.point = new Vector3(0, 0, 500);
        c4.axis = new Vector3(1, 1, 1);
        c4.angle = 50;*/
        var d4 = cube4.AddComponent<MoveTowardAndBack>();
        d4.movement = new Vector3(-10, -10, 10);
        d4.distance = 50;

      
        GameObject cube5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube5.transform.position = new Vector3(25, 25, 475);
        cube5.transform.localScale = new Vector3(50, 50, 50);
        /*var c5 = cube5.AddComponent<RotateAround>();
        c5.point = new Vector3(0, 0, 500);
        c5.axis = new Vector3(1, 1, 1);
        c5.angle = 50;*/
        var d5 = cube5.AddComponent<MoveTowardAndBack>();
        d5.movement = new Vector3(10, 10, -10);
        d5.distance = 50;

        GameObject cube6 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube6.transform.position = new Vector3(-25, 25, 475);
        cube6.transform.localScale = new Vector3(50, 50, 50);
        /*var c6 = cube6.AddComponent<RotateAround>();
        c6.point = new Vector3(0, 0, 500);
        c6.axis = new Vector3(1, 1, 1);
        c6.angle = 50;*/
        var d6 = cube6.AddComponent<MoveTowardAndBack>();
        d6.movement = new Vector3(-10, 10, -10);
        d6.distance = 50;

        GameObject cube7 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube7.transform.position = new Vector3(25, -25, 475);
        cube7.transform.localScale = new Vector3(50, 50, 50);
        /*var c7 = cube7.AddComponent<RotateAround>();
        c7.point = new Vector3(0, 0, 500);
        c7.axis = new Vector3(1, 1, 1);
        c7.angle = 50;*/
        var d7 = cube7.AddComponent<MoveTowardAndBack>();
        d7.movement = new Vector3(10, -10, -10);
        d7.distance = 50;

        GameObject cube8 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube8.transform.position = new Vector3(-25, -25, 475);
        cube8.transform.localScale = new Vector3(50, 50, 50);
        /*var c8 = cube8.AddComponent<RotateAround>();
        c8.point = new Vector3(0, 0, 500);
        c8.axis = new Vector3(1, 1, 1);
        c8.angle = 50;*/
        var d8 = cube8.AddComponent<MoveTowardAndBack>();
        d8.movement = new Vector3(-10, -10, -10);
        d8.distance = 50;



    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
