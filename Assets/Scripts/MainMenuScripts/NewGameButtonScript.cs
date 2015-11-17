using UnityEngine;
using System.Collections;

public class NewGameButtonScript : MonoBehaviour {

    public GameObject mainMenuManager;
    MainMenuManager mainMenuManagerScript;

    void Start()
    {
        mainMenuManagerScript = mainMenuManager.GetComponent<MainMenuManager>();
    }

    void OnMouseDown()
    {
        mainMenuManagerScript.rotateToGameSelectSide();
    }
}
