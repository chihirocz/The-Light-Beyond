using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour 
{
    // -- Singleton Structure
    protected static Fading mInstance;
    public static Fading Instance
    {
        get
        {
            if (mInstance == null)
            {
                GameObject tempObj = new GameObject();
                mInstance = tempObj.AddComponent<Fading>();
                Destroy(tempObj);
            }
            return mInstance;
        }
    }

    // -- Scene to be loaded
    string SceneName = null;
    int SceneNum = 0;

    // -- Whether to do Fade
    bool b_DoFade = false;

    // -- Fade Canvas
    public Canvas FadePrefab;
    Canvas FadeSprite;

    // -- Variables
    float f_Alpha = 1.0f, f_Speed = 1.0f;

    // -- Fade's Type
    public enum E_FadeType
    {
        FADE_IN,
        FADE_OUT
    } E_FadeType Type;


    private enum SceneIdType
    {
        NAME_ID,
        NUMBER_ID
    } SceneIdType IdType;

    private SceneIdType sceneIdType;

    // -- Instantiate
    void InstantiateFade()
    {
        if (FadePrefab == null)
        {
            Debug.Log("FadePrefab is null in InstantiateFade()");
        }
        if (FadePrefab != null) 
            FadeSprite = Instantiate(FadePrefab, FadePrefab.transform.position, Quaternion.identity) as Canvas;
    }

    // -- Initialisation
    void Start()
    {
        // -- Set Instance
        mInstance = this;

        if (FadePrefab == null)
        {
            Debug.Log("FadePrefab is null");
        }
        
        // -- Start Fading In
        StartFade(null, true);
    }

    // -- Fading Process
    void DoFade(bool Mode)
    {
        // -- Fade-In
        if (Mode)
        {
            if (FadeSprite.GetComponentInChildren<Image>().color.a > 0.0f)
                f_Alpha -= Time.deltaTime * f_Speed;
            else
                b_DoFade = false;
        }

        // -- Fade-Out
        else
        {
            if (FadeSprite.GetComponentInChildren<Image>().color.a < 1.0f)
                f_Alpha += Time.deltaTime * f_Speed;
            else
            {
                b_DoFade = false;

                switch (sceneIdType)
                {
                    case SceneIdType.NAME_ID:
                        SceneManager.LoadScene(SceneName);
                        break;

                    case SceneIdType.NUMBER_ID:
                        SceneManager.LoadScene(SceneNum);
                        break;
                }
            }
        }
    }


    private void StartFade(bool Mode)
    {
        
        // -- Tells Program to do fading
        b_DoFade = true;

        // -- Instantiate if Canvas doesn't exist
        if (FadeSprite == null)
            InstantiateFade();

        // -- Set Default Color
        Color DefaultColor = FadeSprite.GetComponentInChildren<Image>().color;

        // -- Fade-In
        if (Mode)
        {
            this.Type = E_FadeType.FADE_IN;
            FadeSprite.GetComponentInChildren<Image>().color = new Color(DefaultColor.r, DefaultColor.g, DefaultColor.b, 1.0f);
        }

        // -- Fade Out
        else
        {
            this.Type = E_FadeType.FADE_OUT;
            FadeSprite.GetComponentInChildren<Image>().color = new Color(DefaultColor.r, DefaultColor.g, DefaultColor.b, 0.0f);
        }

    }
    // -- Start Fading [THIS IS THE FUNCTION U CALL TO TOGGLE FADING]
    public void StartFade(string SceneName, bool Mode = false)
    {
        // -- Do not constantly reset fade
        if (b_DoFade) return;

        // -- Set Scene to be loaded
        this.SceneName = SceneName;
        this.sceneIdType = SceneIdType.NAME_ID;

        StartFade(Mode);
    }

    public void StartFade(int SceneIdx, bool Mode = false)
    {
        // -- Do not constantly reset fade
        if (b_DoFade) return;

        // -- Set Scene to be loaded
        this.SceneNum = SceneIdx;
        this.sceneIdType = SceneIdType.NUMBER_ID;

        StartFade(Mode);
    }


	// -- Update Func
	void Update () 
    {
        // -- Do Fading Now
        if (b_DoFade)
        {
            // -- Fade's Type
            switch (Type)
            {
                case E_FadeType.FADE_IN:
                    DoFade(true);
                    break;
                case E_FadeType.FADE_OUT:
                    DoFade(false);
                    break;
            }

            // -- Set Default Color
            Color DefaultColor = FadeSprite.GetComponentInChildren<Image>().color;

            // -- Toggle Alpha
            FadeSprite.GetComponentInChildren<Image>().color = new Color(DefaultColor.r, DefaultColor.g, DefaultColor.b, f_Alpha);
        }
	}
}
