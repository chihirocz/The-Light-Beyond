using UnityEngine;
using System.Collections;

public class ApplyScript : MonoBehaviour {

    public GameObject mainMenuManager;
    MainMenuManager mainMenuManagerScript;
    public ResolutionValueScript resValScript;
    public SliderResolutionScript slidResScript;

    void Start()
    {
        mainMenuManagerScript = mainMenuManager.GetComponent<MainMenuManager>();
        slidResScript.numberOfPositions = resValScript.heightResolution.Length;
    }

    void OnMouseDown()
    {
        Screen.SetResolution(resValScript.widthResolution[slidResScript.position], resValScript.heightResolution[slidResScript.position], false);
        mainMenuManagerScript.rotateToBasicSide();
    }
}
