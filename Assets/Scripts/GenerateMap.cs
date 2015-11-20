using UnityEngine;
using System.Collections;

public class GenerateMap : MonoBehaviour {

	//distace to light
	public int mapSize;

	//0-100 % density of cubec 
	public int density;


	public int minCubeSize;
    public int maxCubeSize;


    public int minCubeRotation;
    public int maxCubeRotation;

    public Material cubeMaterial;


    // Use this for initialization
    void Start() {
        float actualDensity=0;
        float actualVolume=0;
        int mapVolume = (mapSize * 2) * (mapSize * 2) * (mapSize * 2);

        while (actualDensity < density) {
            //Collider[] checkResult;
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Renderer rend = cube.GetComponent<Renderer>();
            rend.material = cubeMaterial;
            /*do
            {*/
                cube.transform.position = new Vector3(Random.Range(-mapSize, mapSize),
                                                      Random.Range(-mapSize, mapSize),
                                                      Random.Range(-mapSize, mapSize));
                cube.transform.localScale = new Vector3(Random.Range(minCubeSize, maxCubeSize),
                                                        Random.Range(minCubeSize, maxCubeSize),
                                                        Random.Range(minCubeSize, maxCubeSize));

               /*checkResult = Physics.OverlapSphere(cube.transform.position,
                    Mathf.Sqrt(Mathf.Pow(cube.transform.localScale.x, 2) + (Mathf.Pow(cube.transform.localScale.y, 2) + (Mathf.Pow(cube.transform.localScale.z, 2)))) / 2);
            } while (checkResult.Length != 0);*/


            var c = cube.AddComponent<CubeRotation>();
            c.Xaxis = Random.Range(minCubeRotation, maxCubeRotation);
            c.Yaxis = Random.Range(minCubeRotation, maxCubeRotation);
            c.Zaxis = Random.Range(minCubeRotation, maxCubeRotation);

            actualVolume += cube.transform.localScale.x * cube.transform.localScale.y * cube.transform.localScale.z;
            actualDensity = actualVolume / mapVolume * 100;
        }


    }
	
	// Update is called once per frame
	void Update () {

    }
}
