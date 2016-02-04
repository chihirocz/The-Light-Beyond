using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {
	public float sizeX;
	public float sizeY;
	public float sizeZ;

	public float positionX;
	public float positionY;
	public float positionZ;

	public float maxRotationX;
	public float maxRotationY;
	public float maxRotationZ;

	public int minDepth;
	public int maxDepth;
	public int maxMove;

	public float safeZone;

	public Object cubeObj;

	public Object bonus1Obj;

	public Object bonus2Obj;

	public Object bonus3Obj;

	public Object bonus4Obj;

	public int timesToMove;
	public int timesToUnsafeMove;

	public int pRozdel;
	public int pCube; 
	public int pBonus;
	GameObject father;

	public void Generate()
	{
		father = new GameObject("Cubes");
		rekurzia(0, positionX, positionY, positionZ, sizeX, sizeY, sizeZ);
	}

	public void skusPosunut (){
		if (father == null) {
			father = GameObject.Find ("Cubes");
			if (father == null) {
				print ("first generate");
				return;
			}
		}
		int numChilds = father.transform.childCount;
		for (int i = 0; i < numChilds; i++) {
			GameObject cube = father.transform.GetChild (i).gameObject;	
			SphereCollider spcoll = cube.AddComponent<SphereCollider> ();
			spcoll.center.Set (0.0f, 0.0f, 0.0f);
			spcoll.radius = 0.8f;
		}
		for (int j = 0; j < timesToMove; j++) {	
			for (int i = 0; i < numChilds; i++) {
				GameObject cube = father.transform.GetChild (i).gameObject;
				Vector3 startPosition = cube.transform.localPosition;
				cube.transform.rotation = Random.rotation;
				cube.transform.localPosition += new Vector3 (Random.Range (1, maxMove) * 0.01f * cube.transform.localScale.x, Random.Range (1, maxMove) * 0.01f * cube.transform.localScale.y, Random.Range (1, maxMove) * 0.01f * cube.transform.localScale.z);
				//Collider[] colliders = Physics.OverlapSphere (cube.transform.localPosition, Mathf.Sqrt (3) * cube.transform.localScale.x);
				Collider[] colliders = Physics.OverlapSphere (cube.transform.localPosition, Mathf.Sqrt(3) * cube.transform.localScale.x );
				if (colliders.Length > 2) {
					cube.transform.localPosition = startPosition;
				}
			}
		}
		for (int i = 0; i < numChilds; i++) {
			GameObject cube = father.transform.GetChild (i).gameObject;	
			SphereCollider spcoll = cube.GetComponent<SphereCollider>();
			DestroyImmediate(spcoll);
		}
	}

	private void rekurzia(int zanorenie, float x, float y, float z, float sizeX, float sizeY, float sizeZ){
		if (zanorenie < minDepth) {
			rozdel(zanorenie, x, y, z, sizeX, sizeY, sizeZ);
		}else if(zanorenie >= maxDepth){
			if(pCube < Random.Range (0, 100)){
				prazdne();
			}else{
				vytvornieco(zanorenie, x, y, z, sizeX, sizeY, sizeZ);
			}
		}else{
			if(pRozdel < Random.Range(0, 100)){
				rozdel(zanorenie, x, y, z, sizeX, sizeY, sizeZ);
			}else{
				if(pCube < Random.Range (0, 100)){
					prazdne();
				}else{
					vytvornieco(zanorenie, x, y, z, sizeX, sizeY, sizeZ);
				}
			}
		}
	}

	private void rozdel (int zanorenie, float x, float y, float z, float sizeX, float sizeY, float sizeZ)
	{
		rekurzia (zanorenie + 1, x					, y					, z					, sizeX / 2, sizeY / 2, sizeZ / 2);
		rekurzia (zanorenie + 1, x - (sizeX / 2)	, y					, z					, sizeX / 2, sizeY / 2, sizeZ / 2);
		rekurzia (zanorenie + 1, x					, y - (sizeY / 2)	, z					, sizeX / 2, sizeY / 2, sizeZ / 2);
		rekurzia (zanorenie + 1, x - (sizeX / 2)	, y - (sizeY / 2)	, z					, sizeX / 2, sizeY / 2, sizeZ / 2);
		rekurzia (zanorenie + 1, x					, y					, z - (sizeZ / 2)	, sizeX / 2, sizeY / 2, sizeZ / 2);
		rekurzia (zanorenie + 1, x - (sizeX / 2)	, y					, z - (sizeZ / 2)	, sizeX / 2, sizeY / 2, sizeZ / 2);
		rekurzia (zanorenie + 1, x					, y - (sizeY / 2)	, z - (sizeZ / 2)	, sizeX / 2, sizeY / 2, sizeZ / 2);
		rekurzia (zanorenie + 1, x - (sizeX / 2)	, y - (sizeY / 2)	, z - (sizeZ / 2)	, sizeX / 2, sizeY / 2, sizeZ / 2);
	}

	private void vytvornieco(int zanorenie, float x, float y, float z, float sizeX, float sizeY, float sizeZ)
	{
		if(pBonus >= Random.Range(0, 100)){
			createBonus (zanorenie, x, y, z, sizeX, sizeY, sizeZ);
		}else{
			createCube (zanorenie, x, y, z, sizeX, sizeY, sizeZ);
		}
	}

	private void createCube (int zanorenie, float x, float y, float z, float sizeX, float sizeY, float sizeZ)
	{
		GameObject cubetmp =  Instantiate (cubeObj, Vector3.zero, Quaternion.identity) as GameObject;
		cubetmp.transform.position = new Vector3 (x - sizeX/2, y - sizeY/2, z - sizeZ/2);

		cubetmp.transform.parent = father.transform;
		float size = Mathf.Min (sizeX, Mathf.Min (sizeY, sizeZ));
		size = size / Mathf.Sqrt (3);
		cubetmp.transform.localScale = new Vector3 (size, size, size);
		CubeRotation cubeRotationScript = cubetmp.GetComponent<CubeRotation> ();
		cubeRotationScript.Xaxis = Random.Range (0, maxRotationX);
		cubeRotationScript.Yaxis = Random.Range (0, maxRotationY);
		cubeRotationScript.Zaxis = Random.Range (0, maxRotationZ);
	}

	private void createBonus(int zanorenie, float x, float y, float z, float sizeX, float sizeY, float sizeZ)
	{
		GameObject bonusTmp;
		int numBonus = Random.Range (1, 5);
		if (numBonus == 1) {
			bonusTmp =  Instantiate (bonus1Obj, Vector3.zero, Quaternion.identity) as GameObject;
			bonusTmp.name = "Powerup_Disappear";
		} else if (numBonus == 2) {
			bonusTmp =  Instantiate (bonus2Obj, Vector3.zero, Quaternion.identity) as GameObject;
			bonusTmp.name = "Powerup_Freeze";
		} else if (numBonus == 3) {
			bonusTmp =  Instantiate (bonus3Obj, Vector3.zero, Quaternion.identity) as GameObject;
			bonusTmp.name = "Powerup_Navigate";
		} else{
			bonusTmp =  Instantiate (bonus4Obj, Vector3.zero, Quaternion.identity) as GameObject;
			bonusTmp.name = "Powerup_PlusLife";
		}
		bonusTmp.transform.position = new Vector3 (x - sizeX/2, y - sizeY/2, z - sizeZ/2);
		bonusTmp.transform.parent = father.transform;
	}

	private void prazdne()
	{
		
	}

	public void makeSafe()
	{
		if (father == null) {
			father = GameObject.Find ("Cubes");
			if (father == null) {
				print ("first generate");
				return;
			}
		}
		int numChilds = father.transform.childCount;
		for (int i = 0; i < numChilds; i++) {
			GameObject cube = father.transform.GetChild (i).gameObject;	
			SphereCollider spcoll = cube.AddComponent<SphereCollider> ();
			spcoll.center.Set (0.0f, 0.0f, 0.0f);
			spcoll.radius = 0.8f;
		}	

		GameObject player = GameObject.Find("Player");
		GameObject finish = GameObject.Find ("Final light menu");
		if (player == null) {
			print ("missing player");
			return;
		}
		if (finish == null) {
			print ("missing light");
			return;
		}
		Collider[] colliders = Physics.OverlapSphere (player.transform.localPosition, safeZone);
		foreach (Collider coll in colliders) {
			if ((coll.gameObject.name != "Final light menu") && (coll.gameObject.name != "Player")) {
				coll.gameObject.tag = "ToDestroy";
			}
		}
		colliders = Physics.OverlapSphere (finish.transform.localPosition, safeZone);
		foreach (Collider coll in colliders) {
			if ((coll.gameObject.name != "Final light menu") && (coll.gameObject.name != "Player")) {
				coll.gameObject.tag = "ToDestroy";
			}
		}
		numChilds = father.transform.childCount;
		for (int i = 0; i < numChilds; i++) {
			GameObject cube = father.transform.GetChild (i).gameObject;	
			SphereCollider spcoll = cube.GetComponent<SphereCollider>();
			DestroyImmediate(spcoll);
		}
		GameObject[] toDestroy = GameObject.FindGameObjectsWithTag ("ToDestroy");
		for (int i = 0; i < toDestroy.Length; i++) {
			DestroyImmediate (toDestroy[i]);
		}
	}

	public void unsaveMove(){
		if (father == null) {
			father = GameObject.Find ("Cubes");
			if (father == null) {
				print ("first generate");
				return;
			}
		}
		int numChilds = father.transform.childCount;
		for (int i = 0; i < numChilds; i++) {
			GameObject cube = father.transform.GetChild (i).gameObject;	
			SphereCollider spcoll = cube.AddComponent<SphereCollider> ();
			spcoll.center.Set (0.0f, 0.0f, 0.0f);
			spcoll.radius = 0.8f;
		}
		for (int j = 0; j < timesToUnsafeMove; j++) {	
			for (int i = 0; i < numChilds; i++) {
				GameObject cube = father.transform.GetChild (i).gameObject;
				Vector3 startPosition = cube.transform.localPosition;
				cube.transform.rotation = Random.rotation;
				cube.transform.localPosition += new Vector3 (Random.Range (1, maxMove) * 0.01f * cube.transform.localScale.x, Random.Range (1, maxMove) * 0.01f * cube.transform.localScale.y, Random.Range (1, maxMove) * 0.01f * cube.transform.localScale.z);
			}
		}
		for (int i = 0; i < numChilds; i++) {
			GameObject cube = father.transform.GetChild (i).gameObject;	
			SphereCollider spcoll = cube.GetComponent<SphereCollider>();
			DestroyImmediate(spcoll);
		}
	}


	public bool makeNonTuching(){
		if (father == null) {
			father = GameObject.Find ("Cubes");
			if (father == null) {
				print ("first generate");
				return false;
			}
		}
		int numChilds = father.transform.childCount;
		for (int i = 0; i < numChilds; i++) {
			GameObject cube = father.transform.GetChild (i).gameObject;	
			SphereCollider spcoll = cube.AddComponent<SphereCollider> ();
			spcoll.center.Set (0.0f, 0.0f, 0.0f);
			spcoll.radius = 0.8f;
		}	
		for (int i = 0; i < numChilds; i++) {
			GameObject cube = father.transform.GetChild (i).gameObject;
			Vector3 startPosition = cube.transform.localPosition;
			int maxTries = 20;
			int tries = 0;
			Collider[] colliders;
			do{
				cube.transform.localPosition = startPosition;
				cube.transform.rotation = Random.rotation;
				cube.transform.localPosition += new Vector3 (Random.Range (1, maxMove) * 0.01f * cube.transform.localScale.x, Random.Range (1, maxMove) * 0.01f * cube.transform.localScale.y, Random.Range (1, maxMove) * 0.01f * cube.transform.localScale.z);
				colliders = Physics.OverlapSphere (cube.transform.localPosition, Mathf.Sqrt(3) * cube.transform.localScale.x );
				if(maxTries >= tries){
					return false;
				}
			}while(colliders.Length > 2);
		}
		for (int i = 0; i < numChilds; i++) {
			GameObject cube = father.transform.GetChild (i).gameObject;	
			SphereCollider spcoll = cube.GetComponent<SphereCollider>();
			DestroyImmediate(spcoll);
		}
		return true;
	}
}
