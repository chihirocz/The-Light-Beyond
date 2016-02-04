using UnityEngine;
using System.Collections;

public class EasyLevelGenerator : MonoBehaviour {


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
		mg.maxRotationX = 10;
		mg.maxRotationY = 10;
		mg.maxRotationZ = 10;
		mg.sizeX = 1000;
		mg.sizeY = 1000;
		mg.sizeZ = 1000;
		mg.positionX = 500;
		mg.positionY = 500;
		mg.positionZ = 500;
		mg.timesToMove = 40;
		mg.timesToUnsafeMove = 0;
		mg.safeZone = 80;
		mg.pRozdel = 75;
		mg.pCube = 45;
		mg.pBonus = 3;

		player.transform.localPosition = new Vector3 (Random.Range (100, 450), Random.Range (200, 450), Random.Range (300, 450));
		light.transform.localPosition = new Vector3 (Random.Range (-450, -300), Random.Range (-450, -250), Random.Range (-450, -150));

		mg.Generate();
		mg.makeSafe();
		mg.skusPosunut();
		mg.makeSafe();
	}

}
