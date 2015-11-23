using UnityEngine;
using System.Collections;

public class BackScript : MonoBehaviour {

    public GameObject mainMenuManager;
    MainMenuManager mainMenuManagerScript;

    void Start()
    {
        mainMenuManagerScript = mainMenuManager.GetComponent<MainMenuManager>();
    }

    void OnMouseDown()
    {
        mainMenuManagerScript.rotateToBasicSide();
    }
}
