using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showLifes : MonoBehaviour {

    private Text text = null;
    private GameManager gameManager = null;


    // Use this for initialization
    void Start () {

        text = gameObject.GetComponent<Text>();

        GameObject o = GameObject.Find("GameManager");
        if (o != null)
        {
            gameManager = o.GetComponent<GameManager>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(text != null && gameManager != null)
        {
            text.text = "Lifes: " + gameManager.numberOfLifes.ToString();
        }
    }
}
