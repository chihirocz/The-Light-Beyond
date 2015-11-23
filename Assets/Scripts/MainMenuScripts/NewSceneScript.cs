using UnityEngine;
using System.Collections;

public class NewSceneScript : MonoBehaviour {

    public GameObject mainMenuManager;
    MainMenuManager mainMenuManagerScript;
    public string sceneToLoad;

    void Start()
    {
        mainMenuManagerScript = mainMenuManager.GetComponent<MainMenuManager>();
    }

    void OnMouseDown()
    {
        Application.LoadLevel(sceneToLoad);
    }
}
