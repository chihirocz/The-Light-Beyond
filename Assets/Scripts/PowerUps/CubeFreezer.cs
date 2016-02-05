using UnityEngine;
using System.Timers;
using System.Collections.Generic;
using System;


public class CubeFreezer : MonoBehaviour {
	
	private List<CubeRotation> rotationScriptsOfCubes = new List<CubeRotation>();
    private Timer timer;
	public bool isOn;

    void Start ()
    {
		/*
		if (cubeObjects != null || cubeObjects.Length != 0){
            Array.Clear(cubeObjects, 0, cubeObjects.Length);
        }
		if (rotationScriptsOfCubes != null || rotationScriptsOfCubes.Count != 0) {
			//Array.Clear (rotationScriptsOfCubes, 0, rotationScriptsOfCubes.Length);
			rotationScriptsOfCubes.Clear();
		}*/
		isOn = false;
		GameObject[] cubeObjects = GameObject.FindGameObjectsWithTag("Cube");

		if (cubeObjects.Length != 0 && cubeObjects != null) 
		{
			foreach (GameObject cube in cubeObjects) 
			{
				rotationScriptsOfCubes.Add(cube.GetComponent<CubeRotation>());
			}
		}
    }

    public void Run()
    {
        ContinueRotation(false);
		isOn = true;
        SetTimer();
    }

    private void ContinueRotation(bool rotate)
    {
		if (rotationScriptsOfCubes == null || rotationScriptsOfCubes.Count == 0) {
			return;
		}
        foreach(CubeRotation rot in rotationScriptsOfCubes)
        {
            rot.rotate = rotate;
        }
    }

    private void OnTimeEvent(object source, ElapsedEventArgs e)
    {
        ContinueRotation(true);
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
