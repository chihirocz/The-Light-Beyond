using UnityEngine;
using System.Collections;

public class SelectBackMenuButtonScript : MonoBehaviour {
    
    public GameObject mainMenuManager;
    MainMenuManager mainMenuManagerScript;
    public GameObject Back;

    void Start()
    {
        mainMenuManagerScript = mainMenuManager.GetComponent<MainMenuManager>();
    }

    void OnMouseDown()
    {
        Back.SetActive(true);
        mainMenuManagerScript.rotateToBacSide();
    }
}
