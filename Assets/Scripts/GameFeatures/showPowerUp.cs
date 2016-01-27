using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showPowerUp : MonoBehaviour {

    private Text text = null;
    private PlayerBehaviour player = null;

    // Use this for initialization
    void Start () {

        text = gameObject.GetComponent<Text>();

        GameObject o = GameObject.Find("Player");
        if (o != null)
        {
            player = o.GetComponent<PlayerBehaviour>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (text != null && player != null)
        {
            text.text = "Powerup: " + player.GetPowerup();
        }
    }
}
