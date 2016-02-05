using UnityEngine;
using System.Collections;

public class NewSceneScript : MonoBehaviour {

    GameManager gameManagerScript = null;
    public string nameOfSceneToLoad = "";

    void Start()
    {
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
            gameManagerScript.LoadLevel(nameOfSceneToLoad);
        }
    }
}
