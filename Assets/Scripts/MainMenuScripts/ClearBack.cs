using UnityEngine;
using System.Collections;

public class ClearBack : MonoBehaviour {
    public GameObject mainMenuManager;
    MainMenuManager mainMenuManagerScript;
    public GameObject actualBackSide;

    void Start()
    {
        mainMenuManagerScript = mainMenuManager.GetComponent<MainMenuManager>();
    }

    void OnMouseDown()
    {
		StartCoroutine ("waitLittle");
    }

	IEnumerator waitLittle(){
		yield return new WaitForSeconds (0.5f);
		actualBackSide.SetActive(false);
	}
}
