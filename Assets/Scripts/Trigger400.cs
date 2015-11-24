using UnityEngine;
using System.Collections;

public class Trigger400 : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.Find("Player");
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z+50);
        cube.transform.localScale = new Vector3(50, 50, 50);
        var c = cube.AddComponent<MoveTowardAndBack>();
        c.movement = player.transform.position;
        c.distance = 50;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
