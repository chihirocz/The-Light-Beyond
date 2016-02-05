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
		audos = gm.GetComponent<AudioSource>();
		onDown = Resources.Load ("Audio/switch") as AudioClip;
		onExit = Resources.Load ("Audio/Click2") as AudioClip;
		onEnter = Resources.Load ("Audio/Click2") as AudioClip;
	}
	
	public void onDownFunct()
	{
		if(audos != null){
			audos.PlayOneShot (onDown, gm.soundVolume);
		}
	}

	public void onEnterFunct()
	{
		if (audos != null) {
			audos.PlayOneShot (onEnter, gm.soundVolume * 0.5f);
		}
	}
}
