using UnityEngine;
using System.Collections;

public class MoveTowardAndBack : MonoBehaviour {

    public Vector3 movement = Vector3.zero;
    public float distance = 0f;
    //public bool move = true;

    private Vector3 lastPosition;
    private float distanceTravelled = 0f;

    // Use this for initialization
    void Start () {
        lastPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
       // if (move)
        //{
            if (distanceTravelled < distance)
            {
            
            transform.Translate(movement * Time.deltaTime);
            
            distanceTravelled += (lastPosition - transform.position).magnitude;//Vector3.Distance(lastPosition, transform.position);
            lastPosition = transform.position;
            }
            else
            {
                Debug.Log(this.name+" "+distanceTravelled);
                distanceTravelled = 0f;
                movement=-movement;
            }
        //}
    }
}
