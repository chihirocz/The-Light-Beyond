using UnityEngine;
using System.Collections;
using System;


public class PlayerBehaviour : MonoBehaviour {
	
	public float xStartingPos = 0f;
	public float yStartingPos = 0f;
	public float zStartingPos = 0f;

    private bool cubeDisappearerOn;
    private bool cubeFreezerOn;
    private bool navigationOn;
    private int lifes;

    private GameObject[] cubeObjects;

    private System.Random random;
    CubeDisappearer myDis;
    CubeFreezer myFreez;
    Navigation myNav;


    // Use this for initialization
    void Start () 
	{
		this.transform.position = new Vector3(xStartingPos, yStartingPos, zStartingPos);

        if (cubeObjects != null)
        {
            Array.Clear(cubeObjects, 0, cubeObjects.Length);
        }
        cubeObjects = GameObject.FindGameObjectsWithTag("Cube");

        cubeDisappearerOn = false;
        cubeFreezerOn = false;
        navigationOn = false;
        lifes = 1;

		random = new System.Random ();
        myDis = gameObject.AddComponent <CubeDisappearer>() as CubeDisappearer;
		myFreez = gameObject.AddComponent <CubeFreezer>() as CubeFreezer;
		myNav = gameObject.AddComponent <Navigation> () as Navigation;
    }
	

	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (cubeDisappearerOn)
            {
                myDis.Run();
                cubeDisappearerOn = false;
            }
            else if (cubeFreezerOn)
            {
                myFreez.Run();
                cubeFreezerOn = false;
            }
            else if (navigationOn)
            {
                myNav.Run();
                navigationOn = false;
            }
        }
	}


    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "Cube")
        {
            lifes--;
			this.transform.position = new Vector3(xStartingPos, yStartingPos, zStartingPos);;
			if (lifes == 0)
            {
				// TO DO restart
				Debug.Log("restart");
			}
        }
        else if (col.gameObject.tag == "Light")
        {
			// TO DO nextLevel
			Debug.Log("next level");
        }
        else if (col.gameObject.tag == "CubeDisappearer")
        {
            cubeDisappearerOn = true;
            Debug.Log("cube disappeared");
        }
        else if (col.gameObject.tag == "CubeFreezer")
        {
            cubeFreezerOn = true;
            Debug.Log("cube freezer");
        }
        else if (col.gameObject.tag == "Navigation")
        {
            navigationOn = true;
            Debug.Log("navigation");
        }
        else if (col.gameObject.tag == "PlusLife")
        {
            lifes++;
            Debug.Log("plus life");
        }
        else if (col.gameObject.tag == "RandomPowerup")
        {
            switch (random.Next(1, 4))
            {
                case 1:
                    cubeDisappearerOn = true;
					Debug.Log("RandomPowerup cube disapperer");
                    break;
                case 2:
                    cubeFreezerOn = true;
					Debug.Log("RandomPowerup cube freezer");
					break;
                case 3:
                    navigationOn = true;
					Debug.Log("RandomPowerup navigation");
                    break;
                case 4:
                    lifes++;
					Debug.Log("RandomPowerup plus life");
                    break;
            }
        }
    }
}
