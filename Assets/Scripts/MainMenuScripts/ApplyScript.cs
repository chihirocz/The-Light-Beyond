using UnityEngine;
using System.Collections;

public class ApplyScript : MonoBehaviour {

    public GameObject mainMenuManager;
    MainMenuManager mainMenuManagerScript;
	public MovingSliderScript soundScript;
	public MovingSliderScript musicScript;
	GameManager gm;
    //public ResolutionValueScript resValScript;
    //public SliderResolutionScript slidResScript;

    void Start()
    {
		gm = GameObject.FindObjectOfType<GameManager> ();
        mainMenuManagerScript = mainMenuManager.GetComponent<MainMenuManager>();
        //slidResScript.numberOfPositions = resValScript.heightResolution.Length;
		if (gm != null) {
			soundScript.setVolume (gm.soundVolume);
			musicScript.setVolume (gm.musicVolume);
		}
	}

    void OnMouseDown()
    {
       // Screen.SetResolution(resValScript.widthResolution[slidResScript.position], resValScript.heightResolution[slidResScript.position], false);
        mainMenuManagerScript.rotateToBasicSide();
		if (gm != null) {
			gm.setMusicVolume (musicScript.value);
			gm.setSoundVolume (soundScript.value);
		}
    }
}
