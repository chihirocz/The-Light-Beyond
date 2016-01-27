using UnityEngine;
using System.Collections;

public class NavigatorControl : MonoBehaviour {

    /*public float xPos = 0;
    public float yPos = 0;
    public float zPos = 0;*/

    private GameObject lightObject = null;
	private GameObject player = null;


	// Use this for initialization
	void Start () {
        if(lightObject == null)
        {
            lightObject = GameObject.FindGameObjectWithTag("Light");
        }
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt(lightObject.transform.position);
		this.transform.position = player.transform.position + (player.transform.forward * 10);
    }
}
