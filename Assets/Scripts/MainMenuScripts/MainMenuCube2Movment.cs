using UnityEngine;
using System.Collections;

public class MainMenuCube2Movment : MonoBehaviour {


	public int Xaxis = 20;
	public int Yaxis = 20;
	public int Zaxis = 20;
	public float Xtime = 5.0f;
	public float Ytime = 3.0f;
	public float Ztime = 8.0f;
	public int X;
	public int Y;
	public int Z;
	int count = 0;
	float start;

	/*void Start (){
		start = 
	}*/

	void Update () {
		if (Mathf.Round (Time.timeSinceLevelLoad / Xtime) % 2 == 0) {
			X = Xaxis;
		} else {
			X = -Xaxis;
		}

		if (Mathf.Round (Time.timeSinceLevelLoad / Ytime) % 2 == 0) {
			Y = Yaxis;
		} else {
			Y = -Yaxis;
		}

		if (Mathf.Round (Time.timeSinceLevelLoad / Ztime) % 2 == 0) {
			Z = Zaxis;
		} else {
			Z = -Zaxis;
		}

		transform.Rotate(X * Time.deltaTime, Y * Time.deltaTime, Z * Time.deltaTime);
	}
}
