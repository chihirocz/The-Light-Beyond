using UnityEngine;
using System.Collections;
using System;


public class PlayerBehaviour : MonoBehaviour {
	
	/*public float xStartingPos = 0f;
	public float yStartingPos = 0f;
	public float zStartingPos = 0f;*/
    private Vector3 starting_position;

    private bool cubeDisappearerOn;
    private bool cubeFreezerOn;
    private bool navigationOn;

    private GameObject[] cubeObjects;

    private System.Random random;
    private CubeDisappearer myDis = null;
    private CubeFreezer myFreez = null;
    private Navigation myNav = null;

    private GameManager gameManagerScript = null;


    // Use this for initialization
    void Start () 
	{
		//this.transform.position = new Vector3(xStartingPos, yStartingPos, zStartingPos);
        this.starting_position = this.transform.position;
    
        if (cubeObjects != null)
        {
            Array.Clear(cubeObjects, 0, cubeObjects.Length);
        }
        cubeObjects = GameObject.FindGameObjectsWithTag("Cube");

        cubeDisappearerOn = false;
        cubeFreezerOn = false;
        navigationOn = false;

		random = new System.Random ();
        myDis = gameObject.AddComponent <CubeDisappearer>() as CubeDisappearer;
		myFreez = gameObject.AddComponent <CubeFreezer>() as CubeFreezer;
		myNav = gameObject.AddComponent <Navigation> () as Navigation;

        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
            gameManagerScript = gameManager.GetComponent<GameManager>();
        }
        else
        {
            Debug.Log("GameManager is null in MainMenuManager");
        }
    }
	

	// Update is called once per frame
	void Update () {
        if (cubeDisappearerOn)
        {
            if (myDis != null)
            {
                myDis.Run();
                cubeDisappearerOn = false;
            }
        }
        if (cubeFreezerOn)
        {
            if (myFreez != null)
            {
                myFreez.Run();
                cubeFreezerOn = false;
            }
        }
        if (navigationOn)
        {
            if(myNav != null)
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
            this.transform.position = this.starting_position;

            if (gameManagerScript != null)
            {
                if (gameManagerScript.numberOfLifes == 0)
                {
                    Debug.Log("restart");
                    gameManagerScript.LoadLevel("GameOver");
                }
                gameManagerScript.numberOfLifes--;
            }
        }
        else if (col.gameObject.tag == "Light")
        {
            Debug.Log("next level");
            if (gameManagerScript != null)
            {
				gameManagerScript.increaseLevelDone ();
                gameManagerScript.LoadNextLevel();
            }
        }
        else if (col.gameObject.tag == "CubeDisappearer")
        {
            col.gameObject.SetActive(false);
            cubeDisappearerOn = true;
            Debug.Log("cube disappeared");
        }
        else if (col.gameObject.tag == "CubeFreezer")
        {
            col.gameObject.SetActive(false);
            cubeFreezerOn = true;
            Debug.Log("cube freezer");
        }
        else if (col.gameObject.tag == "Navigation")
        {

            col.gameObject.SetActive(false);
            navigationOn = true;
            Debug.Log("navigation");
        }
        else if (col.gameObject.tag == "PlusLife")
        {
            col.gameObject.SetActive(false);
            if(gameManagerScript != null)
            {
                gameManagerScript.numberOfLifes++;
            }
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
                    if (gameManagerScript != null)
                    {
                        gameManagerScript.numberOfLifes++;
                    }
                    Debug.Log("RandomPowerup plus life");
                    break;
            }
        }
    }

    public string GetPowerup()
    {
        if (cubeDisappearerOn)
        {
            return "cube disappearer";
        } else if (cubeFreezerOn)
        {
            return "cube freezer";
        } else if (navigationOn)
        {
            return "navigation";
        }
        return "no powerup";
    }
}
