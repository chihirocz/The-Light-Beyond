using UnityEngine;
using System.Collections;

public class NewSceneScript : MonoBehaviour {

    public GameObject mainMenuManager;
    MainMenuManager mainMenuManagerScript;
    GameManager gameManagerScript = null;
    public string nameOfSceneToLoad = "";
    public int difficultyOfLevel = 1;

    void Start()
    {
        mainMenuManagerScript = mainMenuManager.GetComponent<MainMenuManager>();

        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
            gameManagerScript = gameManager.GetComponent<GameManager>();
        }
        else
        {
            Debug.Log("GameManager is null in NewSceneScript");
        }
    }

    void OnMouseDown()
    {
        if (gameManagerScript != null)
        {
            if (nameOfSceneToLoad == "generated_scene")
            {
                gameManagerScript.LoadLevel(nameOfSceneToLoad, difficultyOfLevel);
            } else
            {
                gameManagerScript.LoadLevel(nameOfSceneToLoad);
            }
        }
    }
}
