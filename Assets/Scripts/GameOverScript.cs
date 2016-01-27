using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

    GameManager gameManagerScript = null;

    // Use this for initialization
    void Start () {

        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
            gameManagerScript = gameManager.GetComponent<GameManager>();
        }
        if(gameManagerScript != null)
        {
            gameManagerScript.SetCurrentLevel(0);
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("show cursor");
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.button == 0 && e.isMouse)
        {
            gameManagerScript.LoadLevel(1);
        }
    }
}
