using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public int totalNumberOfLevels = 0;
    private int currentScene = 1;
    private Scene[] allLevels;
    private int currentLevel = 1;

    public int startMapSize = 600;
    public int startDensity = 16;
    public int startMinCubeSize = 75;
    public int startMaxCubeSize = 150;
    public int startMinCubeRotation = 0;
    public int startMaxCubeRotation = 40;

    public int increaseMapSize = 100;
    public int increaseDensity = 5;
    public int increaseMinCubeSize = 0;
    public int increaseMaxCubeSize = 10;
    public int increaseMinCubeRotation = 0;
    public int increaseMaxCubeRotation = 10;

    public int numberOfLifes = 1;

    public static GameManager instance = null;
    private GenerateMap mapGenerator;
	public GameObject gameMenu;
	public GameObject gameExitMenu;
    //public LevelManager levelManager;    



    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        for(int i=1; i<totalNumberOfLevels; i++)
        {
            SceneManager.LoadScene(i);
        }
        allLevels = SceneManager.GetAllScenes();      
        Debug.Log("number of levels " + allLevels.Length.ToString());
        SceneManager.LoadScene("MainMenu");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel(string levelName)
    {
        if(levelName == allLevels[allLevels.Length - 1].name)
        {
            currentLevel++;
            SceneManager.LoadScene(levelName);
            currentScene = SceneManager.GetActiveScene().buildIndex;
            Debug.Log("load level by name");

        } else
        {
            SceneManager.LoadScene(levelName);
            currentScene = SceneManager.GetActiveScene().buildIndex;
        }
    }

    public void LoadLevel(int levelNumber)
    {
        if(levelNumber >= allLevels.Length-1)
        {
            currentScene++;
            currentLevel++;
            SceneManager.LoadScene(allLevels.Length - 1);

            Debug.Log("load level by number " + currentScene.ToString());
        } else
        {
            currentScene = levelNumber;
            SceneManager.LoadScene(levelNumber);
        }  
    }

    public void LoadNextLevel()
    {
        if(currentScene >= allLevels.Length-1)
        {
            currentScene++;
            currentLevel++;
            SceneManager.LoadScene(allLevels.Length - 1);

            Debug.Log("load next level");
        } else
        {
            currentScene++;
            SceneManager.LoadScene(currentScene);
        }
    }

    public void LoadLevel(string levelName, int difficulty)
    {
        if (levelName == allLevels[allLevels.Length - 1].name)
        {
            currentLevel++;
            SceneManager.LoadScene(levelName);
            currentScene = SceneManager.GetActiveScene().buildIndex;

            Debug.Log("load level by name");

            /*GameObject obj = GameObject.Find("Startup");
            if(obj != null)
            {
                mapGenerator = obj.GetComponent<GenerateMap>();
            }
            if (mapGenerator != null)
            {
                mapGenerator.mapSize = startMapSize;
                mapGenerator.density = startDensity;
                mapGenerator.minCubeSize = startMinCubeSize;
                mapGenerator.maxCubeSize = startMaxCubeSize;
                mapGenerator.minCubeRotation = startMinCubeRotation;
                mapGenerator.maxCubeRotation = startMaxCubeRotation;

            } else
            {
                Debug.Log("map generator is null");
            }*/

        }
        else
        {
            SceneManager.LoadScene(levelName);
            currentScene = SceneManager.GetActiveScene().buildIndex;
        }
    }

    public void LoadLevel(int levelNumber, int difficulty)
    {
        if (levelNumber >= allLevels.Length - 1)
        {
            currentScene++;
            currentLevel++;
            SceneManager.LoadScene(allLevels.Length - 1);

            Debug.Log("load level by number " + currentScene.ToString());

            /*GameObject obj = GameObject.Find("Startup");
            if (obj != null)
            {
                mapGenerator = obj.GetComponent<GenerateMap>();
            }
            if (mapGenerator != null)
            {
                mapGenerator.mapSize = startMapSize;
                mapGenerator.density = startDensity;
                mapGenerator.minCubeSize = startMinCubeSize;
                mapGenerator.maxCubeSize = startMaxCubeSize;
                mapGenerator.minCubeRotation = startMinCubeRotation;
                mapGenerator.maxCubeRotation = startMaxCubeRotation;

            }
            else
            {
                Debug.Log("map generator is null");
            }*/

        }
        else
        {
            currentScene = levelNumber;
            SceneManager.LoadScene(levelNumber);
        }
    }

    void OnGUI()
    {
		if (Event.current.Equals(Event.KeyboardEvent("escape")))
        {
			//v MainMenu je ošetrené stalačenie Escape
			if (!(SceneManager.Equals (SceneManager.GetActiveScene (), SceneManager.GetSceneByName ("MainMenu")))) {
				GameWindowMenuOpen ();
				Pause ();
			}
            //LoadLevel(1);
        }          
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }

	public void Pause()
	{
		Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		PlayerMovement pm = PlayerMovement.FindObjectOfType<PlayerMovement>();
		if(pm != null){
		pm.enabled = false;
		}
	}

	public void Unpause()
	{
		Time.timeScale = 1;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		PlayerMovement pm = PlayerMovement.FindObjectOfType<PlayerMovement>();
		if(pm != null){
			pm.enabled = true;
		}
	}

	public void Restart()
	{
		//moze sa menit nie som si isty ci to takto chceme
		LoadLevel (SceneManager.GetActiveScene ().buildIndex);
	}

	public void GameWindowMenuClose()
	{
		StopMenuWindowInteraction ();
		gameMenu.SetActive (false);
	}

	public void GameWindowMenuOpen()
	{
		StartMenuWindowInteraction ();
		gameMenu.SetActive (true);
	}

	public void GameExitMenuOpen()
	{
		StopMenuWindowInteraction ();
		gameExitMenu.SetActive (true);
	}

	public void GameExitMenuClose()
	{
		StartMenuWindowInteraction ();
		gameExitMenu.SetActive (false);
	}

	private void StopMenuWindowInteraction()
	{
		Button [] buttons = gameMenu.GetComponentsInChildren<Button>();
		foreach(Button button in buttons){
			button.interactable = false;
		}
	}

	private void StartMenuWindowInteraction()
	{
		Button [] buttons = gameMenu.GetComponentsInChildren<Button>();
		foreach(Button button in buttons){
			button.interactable = true;
		}
	}
}
