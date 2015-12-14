using UnityEngine;
using System.Collections;

public class ClearBack : MonoBehaviour {
    public GameObject mainMenuManager;
    MainMenuManager mainMenuManagerScript;
    public GameObject actualBackSide;

    void Start()
    {
        mainMenuManagerScript = mainMenuManager.GetComponent<MainMenuManager>();
    }

    void OnMouseDown()
    {
        actualBackSide.SetActive(false);
    }
}
