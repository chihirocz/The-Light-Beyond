using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class SoundButtonsBehavior : MonoBehaviour {

	AudioSource audos;
	AudioClip onEnter;
	AudioClip onDown;
	AudioClip onExit;
	GameManager gm;


	// Use this for initialization
	void Start () {
		gm = GameObject.FindObjectOfType<GameManager> ();
		audos = GetComponent<AudioSource>();
		onDown = Resources.Load ("Audio/switch") as AudioClip;
		onExit = Resources.Load ("Audio/Click2") as AudioClip;
		onEnter = Resources.Load ("Audio/Click2") as AudioClip;
	}
	
	void OnMouseEnter()
	{
		if (gm != null) {
			audos.PlayOneShot (onEnter, gm.soundVolume * 0.5f);
		} else {
			audos.PlayOneShot (onEnter, 0.5f);
		}
	}

	public void onEnterFunct()
	{
		if (gm != null) {
			audos.PlayOneShot (onEnter, gm.soundVolume * 0.5f);
		} else {
			audos.PlayOneShot (onEnter, 0.5f);
		}
	}

	/*void OnMouseExit()
	{
		if(gm != null){
			audos.PlayOneShot (onExit, gm.soundVolume);
		} else {
			audos.PlayOneShot (onExit);
		}
	}*/

	void OnMouseDown()
	{
		if(gm != null){
			audos.PlayOneShot (onDown, gm.soundVolume);
		} else {
			audos.PlayOneShot (onDown);
		}
	}

	public void onDownFunct()
	{
		if(gm != null){
			audos.PlayOneShot (onDown, gm.soundVolume);
		} else {
			audos.PlayOneShot (onDown);
		}
	}

}
