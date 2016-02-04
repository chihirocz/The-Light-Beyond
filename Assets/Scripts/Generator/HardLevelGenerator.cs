using UnityEngine;
using System.Collections;

public class HardLevelGenerator : MonoBehaviour {


	public GameObject player;
	public GameObject light;

	public Object cube;
	public Object powerup1;
	public Object powerup2;
	public Object powerup3;
	public Object powerup4;


	void Start () {
		MapGenerator mg = GetComponent<MapGenerator> ();
		if(mg == null){
			return;
		}
		mg.cubeObj = cube;
		mg.bonus1Obj = powerup1;
		mg.bonus2Obj = powerup2;
		mg.bonus3Obj = powerup3;
		mg.bonus4Obj = powerup4;

		mg.maxDepth = 2;
		mg.minDepth = 4;
		mg.maxMove = 40;
		mg.maxRotationX = 25;
		mg.maxRotationY = 25;
		mg.maxRotationZ = 25;
		mg.sizeX = 2000;
		mg.sizeY = 2000;
		mg.sizeZ = 2000;
		mg.positionX = 1000;
		mg.positionY = 1000;
		mg.positionZ = 1000;
		mg.timesToMove = 50;
		mg.timesToUnsafeMove = 0;
		mg.safeZone = 60;
		mg.pRozdel = 85;
		mg.pCube = 65;
		mg.pBonus = 1;

		player.transform.localPosition = new Vector3 (Random.Range (200, 650), Random.Range (400, 650), Random.Range (500, 650));
		light.transform.localPosition = new Vector3 (Random.Range (-650, -700), Random.Range (-650, -450), Random.Range (-650, -450));

		mg.Generate();
		mg.makeSafe();
		mg.skusPosunut();
		mg.makeSafe();
	}
}
