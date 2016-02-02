using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    public GameObject menuCube;
	public GameObject exitMenu;
	public GameObject frontShield;
	string side;
    Vector3 sideToRotate;
    float rotationSpeed = 90.0f;
    public float tmpview = 5;
    float rotation;
    public GameObject[] backSides;

    private GameManager gameManagerScript = null;

    public void LoadScane(int level)
    {
		if (gameManagerScript != null) {
			gameManagerScript.LoadLevel (level);
		} else {
			Application.LoadLevel (level);
		}
    }

    public void ExitApplication()
    {
		if (gameManagerScript != null) {
			gameManagerScript.ExitApplication ();
		} else {
			Application.Quit ();
		}
    }

    public void OpenExitMenu()
    {
		side = "frontExitMenu";
		frontShield.SetActive (true);
		exitMenu.SetActive(true);
    }

    public void CloseExitMenu()
    {
		side = "front";
		frontShield.SetActive (false);
        exitMenu.SetActive(false);
    }

    void Update() {
        float actualPoss = menuCube.transform.eulerAngles.y;

        tmpview = actualPoss;
        if ((sideToRotate.y - actualPoss < Mathf.Abs( rotation * Time.deltaTime)) && (sideToRotate.y - actualPoss > - Mathf.Abs(rotation * Time.deltaTime)))
        {
            rotation = 0.0f;
            menuCube.transform.localEulerAngles = sideToRotate;
			frontShield.SetActive (false);
        }
        menuCube.transform.Rotate(0.0f, rotation * Time.deltaTime, 0.0f);

		//ked sa stalci Esc, implikuje stlacenie tlacidla back alebo exit podla strany na ktorej aktualne je
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if(side.Equals("front")){
				OpenExitMenu();
			}else if(side.Equals("frontExitMenu")){
				CloseExitMenu();
			}else if(side.Equals("back")){
				foreach (GameObject backSide in backSides) {
					//zapnuta zadna strana
					if(backSide.activeSelf == true){
						if (backSide.name.Equals ("CreditsSide")) {
							rotateToBasicSide ();
						} else {
							rotateToGameSelectSide ();
						}
						backSide.SetActive(false);
					}
				}
			}else if(side.Equals("option")){
				rotateToBasicSide ();
			}else if(side.Equals("gameSelect")){
				rotateToBasicSide ();
			}
		}
    }

    void setRotation()
    {
        float oppositSideToRotate = sideToRotate.y + 180;
        float actualPoss = menuCube.transform.eulerAngles.y;
		frontShield.SetActive (true);
        if (oppositSideToRotate > 360)
        {
            actualPoss += 360;
        }
        
        if ((actualPoss > sideToRotate.y) && (actualPoss < oppositSideToRotate))
        {
            rotation = -rotationSpeed;
        }
        else
        {
            rotation = rotationSpeed;
        }
    }

    // Use this for initialization
    void Start()
    {
		side = "front";
        sideToRotate = new Vector3(0.0f, 0.0f, 0.0f);
        rotateToBasicSide();
        CloseExitMenu();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        for(int i = 0; i < backSides.Length; i++)
        {
            backSides[i].SetActive(false);
        }

        GameObject gameManager = GameObject.Find("GameManager");
        if(gameManager != null)
        {
            gameManagerScript = gameManager.GetComponent<GameManager>();
        } else
        {
            Debug.Log("GameManager is null in MainMenuManager");
        }
    }

    public void rotateToOptionSide()
    {
		side = "option";
        sideToRotate = new Vector3(0.0f, 270.0f, 0.0f);
        setRotation();
    }

    public void rotateToGameSelectSide()
    {
		side = "gameSelect";
        sideToRotate = new Vector3(0.0f, 90.0f, 0.0f);
        setRotation();
    }

    public void rotateToBasicSide()
    {
		side = "front";
        sideToRotate = new Vector3(0.0f, 0.0f, 0.0f);
        setRotation();
    }

    public void rotateToBackSide()
    {
		side = "back";
        sideToRotate = new Vector3(0.0f, 180.0f, 0.0f);
        setRotation();
    }
}
