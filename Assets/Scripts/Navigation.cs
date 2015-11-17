using UnityEngine;
using System.Timers;

public class Navigation : MonoBehaviour {

	//private Renderer renderer;
	private GameObject navigator;
    private Timer timer;
	private bool navigatorVisible = false;


	void Start ()
	{
		navigator = GameObject.FindGameObjectWithTag("Navigator");
		/*
		if (navigator != null)
		{
			renderer = navigator.GetComponent<Renderer>();
		}   */     
	}

	void Update ()
	{
		navigator.SetActive (navigatorVisible);
		//renderer.enabled = navigatorVisible;
	}

	public void Run () 
	{
		navigatorVisible = true;
        SetTimer();
    }

    private void OnTimeEvent(object source, ElapsedEventArgs e)
    {
		navigatorVisible = false;	
    }

    private void SetTimer()
    {
        // Create a timer with a 10 seconds interval.
        timer = new Timer(30000);
        // Hook up the Elapsed event for the timer. 
        timer.Elapsed += OnTimeEvent;
        timer.AutoReset = false;
        timer.Enabled = true;
    }
}
