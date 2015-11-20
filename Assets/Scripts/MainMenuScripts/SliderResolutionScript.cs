using UnityEngine;
using System.Collections;

public class SliderResolutionScript : MonoBehaviour {


    public float max = 2.6f;
    public float min = -2.6f;
    float lengthOfSlider;
    public Vector3 basePosition;
    public int numberOfPositions = 1;
    public int position;        // ma hodnoty 0-(numberOfPosition - 1)
    public GameObject resolutionValue;
    ResolutionValueScript resValScript;

    void Start()
    {
        lengthOfSlider = max - min;
        resValScript = resolutionValue.GetComponent<ResolutionValueScript>();
    }
    
    void Update()
    {

    }


    void OnMouseDown()
    {
        basePosition = transform.position;
    }

    void OnMouseDrag()
    {

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, basePosition.y, basePosition.z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 realPosition = new Vector3(-objPosition.x, basePosition.y, basePosition.z);
        realPosition.x = Mathf.Clamp(realPosition.x, min, max);
        transform.position = realPosition;
    }

    void OnMouseUp()
    {
        Vector3 realPosition = transform.position;
        if(numberOfPositions == 1)
        {
            realPosition.x = min;
        }
        else
        {
            int parts = (numberOfPositions - 1) * 2;
            float positonLength = lengthOfSlider / parts;
            for(int i=0; i < numberOfPositions - 1; i++)
            {
                if (((i * 2 * positonLength + min) < realPosition.x) && ((i * 2 * positonLength + positonLength + min) > realPosition.x))
                {
                    position = i;
                    realPosition.x = min + i * 2 * positonLength;
                }
                if (((i * 2 * positonLength + positonLength + min) < realPosition.x) && ((i * 2 * positonLength + 2 * positonLength + min) > realPosition.x))
                {
                    position = i + 1;
                    realPosition.x = min + (i + 1) * 2 * positonLength;
                }
            }
        }
        resolutionValue.GetComponent<TextMesh>().text = resValScript.widthResolution[position].ToString() + "x" + resValScript.heightResolution[position].ToString();
        transform.position = realPosition;
    }


}
