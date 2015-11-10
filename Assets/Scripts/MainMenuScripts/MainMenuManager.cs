using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    public GameObject menuCube;
    public GameObject exitMenu;
    Vector3 sideToRotate;
    float rotationSpeed = 90.0f;
    Rotation rotationCubeMenuScript;
    Rigidbody menuCubeRigitbody;
    public float tmpview = 5;
    float rotation;

    public void LoadScane(int level)
    {
        Application.LoadLevel(level);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void OpenExitMenu()
    {
        exitMenu.SetActive(true);
    }

    public void CloseExitMenu()
    {
        exitMenu.SetActive(false);
    }

    void Update() {
        float actualPoss = menuCube.transform.eulerAngles.y;

        tmpview = actualPoss;
        if ((sideToRotate.y - actualPoss < 2.0f) && (sideToRotate.y - actualPoss > -2.0f))
        {
            rotation = 0.0f;
        }
        menuCube.transform.Rotate(0.0f, rotation * Time.deltaTime, 0.0f);
    }

    void setRotation()
    {
        float oppositSideToRotate = sideToRotate.y + 180;
        float actualPoss = menuCube.transform.eulerAngles.y;
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
        sideToRotate = new Vector3(0.0f, 0.0f, 0.0f);
        menuCubeRigitbody = menuCube.GetComponent<Rigidbody>();
        rotationCubeMenuScript = menuCube.GetComponent<Rotation>();
        rotateToBasicSide();
        CloseExitMenu();
    }

    public void rotateToOptionSide()
    {
        sideToRotate = new Vector3(0.0f, 270.0f, 0.0f);
        setRotation();
    }

    public void rotateToGameSelectSide()
    {
        sideToRotate = new Vector3(0.0f, 90.0f, 0.0f);
        setRotation();
    }

    public void rotateToBasicSide()
    {
        sideToRotate = new Vector3(0.0f, 0.0f, 0.0f);
        setRotation();
    }
}
