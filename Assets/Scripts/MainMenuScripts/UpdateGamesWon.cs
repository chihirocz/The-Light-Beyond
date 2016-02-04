using UnityEngine;
using System.Collections;

public class UpdateGamesWon : MonoBehaviour {

	GameManager gm;
	int gamesDone;
	TextMesh tm;

	void Start () {
		gm = GameObject.FindObjectOfType<GameManager> ();
		if (gm != null) {
			gamesDone = gm.getLevelsDone ();
		} else {
			gamesDone = 0;
		}
		tm = GetComponent<TextMesh> ();
		if(tm != null){
			tm.text = gamesDone.ToString();
		}
	}

}
