using UnityEngine;
using System.Timers;
using System;
using System.Collections.Generic;

public class CubeDisappearer  : MonoBehaviour {

	private GameObject[] cubeObjects;
	//private List<Renderer> renderers = new List<Renderer> ();
    private Timer timer;
	private bool showCubes = true;
	public bool isOn;


	void Start () 
	{
		/*if (cubeObjects != null || cubeObjects.Length != 0) {
			Array.Clear (cubeObjects, 0, cubeObjects.Length);
		}
		if (renderers != null || renderers.Length != 0) {
			Array.Clear(renderers, 0, renderers.Length);
		}*/	
		isOn = false;
		cubeObjects = GameObject.FindGameObjectsWithTag("Cube");

		/*if (cubeObjects.Length != 0 && cubeObjects != null)
		{
			foreach (GameObject cube in cubeObjects)
			{
				renderers.Add(cube.GetComponent<Renderer>());
			}
		} */       
	}

	void Update () 
	{
		/*
		if (renderers == null || renderers.Count == 0) {
			return;
		}
		foreach (Renderer r in renderers) {
			r.enabled = showCubes;			
		}
		*/
		if (cubeObjects == null || cubeObjects.Length == 0) {
			return;
		}
		foreach (GameObject cube in cubeObjects) {
			cube.SetActive(showCubes);
		}
	}

    public void Run()
    {
        showCubes = false;
		isOn = true;
        SetTimer();
    }

    private void OnTimeEvent(object source, ElapsedEventArgs e)
    {
        showCubes = true;
		isOn = false;
    }

    private void SetTimer()
    {
        // Create a timer with a 10 seconds interval.
        timer = new Timer(10000);
        // Hook up the Elapsed event for the timer. 
        timer.Elapsed += OnTimeEvent;
        timer.AutoReset = false;
        timer.Enabled = true;
    }
}
