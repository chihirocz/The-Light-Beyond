using UnityEngine;
using System.Collections;

public class ToGameChooseScript : MonoBehaviour {
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
