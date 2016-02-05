using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudScript : MonoBehaviour {

	public GameObject player;
	PlayerBehaviour plScript;
	CubeDisappearer cdis;
	CubeFreezer cfre;
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
		disappearIcon = GameObject.Find ("DisappearIcon");
		plScript = player.GetComponent<PlayerBehaviour> ();
		livesText = GameObject.Find ("LivesAmount");

		cfre = player.GetComponent<CubeFreezer> ();
		cdis = player.GetComponent<CubeDisappearer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (cdis == null) {
			cdis = player.GetComponent<CubeDisappearer> ();
		} else {
			disappearIcon.SetActive (cdis.isOn);
		}
		if (cfre == null) {
			cfre = player.GetComponent<CubeFreezer> ();
		} else {
			freezIcon.SetActive (cfre.isOn);
		}
		if (gm != null) {
			lives = gm.numberOfLifes;
		}
		livesText.GetComponent<Text> ().text = lives.ToString();
	}
}
