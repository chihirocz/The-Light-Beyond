using UnityEngine;
using System.Collections;

public class BackFromBackScript : MonoBehaviour {
    public GameObject mainMenuManager;
    MainMenuManager mainMenuManagerScript;
    public GameObject actualBackDisplay;

    void Start()
    {
        mainMenuManagerScript = mainMenuManager.GetComponent<MainMenuManager>();
    }

    void OnMouseDown()
    {
        mainMenuManagerScript.rotateToGameSelectSide();
        actualBackDisplay.SetActive(false);
    }
}
