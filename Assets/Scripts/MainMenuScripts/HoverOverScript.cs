using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Material))]
public class HoverOverScript : MonoBehaviour {

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
