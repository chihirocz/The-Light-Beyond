using UnityEngine;
using System.Collections;

public class MovingSliderScript : MonoBehaviour {
    
    public float max = 2.6f;
    public float min = -2.6f;
    public Vector3 basePosition;
    public float value = 1;
    float lengthOfSlider;
	GameManager gm;
    
    void Start () {
        lengthOfSlider = max - min;
		gm = GameObject.FindObjectOfType<GameManager> ();
    }
	
	void Update () {

	}


    void OnMouseDown()
    {
        basePosition = transform.position;
    }

    void OnMouseDrag()
    {

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, basePosition.y, basePosition.z);
        //Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
		Vector3 objPosition = Camera.main.ScreenToViewportPoint(mousePosition);
		Vector3 obj2Position = Camera.main.ViewportToWorldPoint (objPosition);
        //Vector3 realPosition = new Vector3(-objPosition.x, basePosition.y, basePosition.z);
		Vector3 realPosition = new Vector3(-obj2Position.x * 3.2f, basePosition.y, basePosition.z);
        realPosition.x = Mathf.Clamp(realPosition.x, min, max);
        transform.position = realPosition;
    }

    void OnMouseUp()
    {
        value = (transform.position.x - min) / lengthOfSlider;
    }

	public void setVolume(float volume){
		if (gm != null) {
			value = volume;
			transform.localPosition = new Vector3( (max - (1 - value) * lengthOfSlider)/7.87f, transform.localPosition.y, transform.localPosition.z);
		}
	}

}
