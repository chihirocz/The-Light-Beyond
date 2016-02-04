using UnityEngine;
using System.Collections;

public class MediumLevelGenerator : MonoBehaviour {

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
		mg.maxRotationX = 18;
		mg.maxRotationY = 18;
		mg.maxRotationZ = 18;
		mg.sizeX = 1500;
		mg.sizeY = 1500;
		mg.sizeZ = 1500;
		mg.positionX = 750;
		mg.positionY = 750;
		mg.positionZ = 750;
		mg.timesToMove = 45;
		mg.timesToUnsafeMove = 0;
		mg.safeZone = 70;
		mg.pRozdel = 70;
		mg.pCube = 55;
		mg.pBonus = 1;

		player.transform.localPosition = new Vector3 (Random.Range (150, 550), Random.Range (300, 550), Random.Range (400, 450));
		light.transform.localPosition = new Vector3 (Random.Range (-500, -450), Random.Range (-550, -350), Random.Range (-450, -200));

		mg.Generate();
		mg.makeSafe();
		mg.skusPosunut();
		mg.makeSafe();
	}
}
