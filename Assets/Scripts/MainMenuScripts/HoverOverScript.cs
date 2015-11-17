using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Material))]
public class HoverOverScript : MonoBehaviour {

    public string levelToLoad;
    public bool QuitButton = false;
    public TextMesh text;
    public Material baseMaterail;
    public Material hoverOverMaterial;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnMouseEnter()
    {
        rend.material = hoverOverMaterial;
    }

    void OnMouseExit()
    {
        rend.material = baseMaterail;
    }

}
