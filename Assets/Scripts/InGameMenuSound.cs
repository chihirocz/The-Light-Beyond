using UnityEngine;
using System.Collections;

public class InGameMenuSound : MonoBehaviour {
	AudioSource audos;
	AudioClip onEnter;
	AudioClip onDown;
	AudioClip onExit;
	GameManager gm;


	// Use this for initialization
	void Start () {
		gm = GameObject.FindObjectOfType<GameManager> ();

		onDown = Resources.Load ("Audio/switch") as AudioClip;
		onExit = Resources.Load ("Audio/Click2") as AudioClip;
		onEnter = Resources.Load ("Audio/Click2") as AudioClip;
	}
	
	public void onDownFunct()
	{
		audos = GameObject.Find("Player").GetComponent<AudioSource>();
		if(gm != null){
			audos.PlayOneShot (onDown, gm.soundVolume);
		} else {
			audos.PlayOneShot (onDown);
		}
	}

	public void onEnterFunct()
	{
		audos = GameObject.Find("Player").GetComponent<AudioSource>();
		if (gm != null) {
			audos.PlayOneShot (onEnter, gm.soundVolume * 0.5f);
		} else {
			audos.PlayOneShot (onEnter, 0.5f);
		}
	}
}
