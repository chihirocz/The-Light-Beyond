using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    public GameObject menuCube;
    public GameObject exitMenu;
    Vector3 sideToRotate;
    float rotationSpeed = 90.0f;
    public float tmpview = 5;
    float rotation;
    public GameObject[] backSides;

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
        if ((sideToRotate.y - actualPoss < 1.5f) && (sideToRotate.y - actualPoss > -1.5f))
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
        rotateToBasicSide();
        CloseExitMenu();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        for(int i = 0; i < backSides.Length; i++)
        {
            backSides[i].SetActive(false);
        }
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

    public void rotateToBacSide()
    {
        sideToRotate = new Vector3(0.0f, 180.0f, 0.0f);
        setRotation();
    }
}
