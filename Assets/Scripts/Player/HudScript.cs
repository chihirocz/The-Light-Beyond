using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudScript : MonoBehaviour {

	public GameObject player;
	PlayerBehaviour plScript;
	int lives;
	GameManager gm;
	GameObject freezIcon;
	GameObject disappearIcon;
	GameObject livesText;


	// Use this for initialization
	void Start () {
		gm = GameObject.FindObjectOfType<GameManager> ();
		if (gm != null) {
			lives = gm.numberOfLifes;
		} else {
			lives = 1;
		}
		freezIcon = GameObject.Find ("FreezeIcon");
		disappearIcon = GameObject.Find ("DisaooearIcon");
		plScript = player.GetComponent<PlayerBehaviour> ();
		livesText = GameObject.Find ("LivesAmount");
		livesText.GetComponent<Text> ().text = lives.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		disappearIcon.SetActive (plScript.getDisappear());
		freezIcon.SetActive (plScript.getFreeze ());

	}
}
