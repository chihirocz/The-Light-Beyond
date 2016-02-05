using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VignetteEffect : MonoBehaviour {

    // -- Singleton Structure
    protected static VignetteEffect mInstance;
    public static VignetteEffect Instance
    {
        get
        {
            if (mInstance == null)
            {
                GameObject tempObj = new GameObject();
                mInstance = tempObj.AddComponent<VignetteEffect>();
                Destroy(tempObj);
            }
            return mInstance;
        }
    }
    

    public enum EffectType
    {
        DAMAGE,
        POWERUP
    } EffectType EffectType_t;


    public Canvas damageVignettePrefab;
    public Canvas powerupVignettePrefab;
    Canvas damageVignetteSprite;
    Canvas powerupVignetteSprite;

    private Vector2 screenSize;
    private bool effectEnabled = false;
    private EffectType effectType;

    void InstantiateDamageVignette()
    {
        if (damageVignettePrefab != null)
            damageVignetteSprite = Instantiate(damageVignettePrefab, damageVignettePrefab.transform.position, Quaternion.identity) as Canvas;
    }

    void InstantiatePowerupVignette()
    {
        if (powerupVignettePrefab != null)
        powerupVignetteSprite = Instantiate(powerupVignettePrefab, powerupVignettePrefab.transform.position, Quaternion.identity) as Canvas;
    }

    float f_Duration = 3.0f;


	// Use this for initialization
	void Start () {
        mInstance = this;
        screenSize = new Vector2(Screen.width, Screen.height);

        InstantiateDamageVignette();
        InstantiatePowerupVignette();

        this.powerupVignetteSprite.GetComponentInChildren<Image>().canvasRenderer.SetAlpha(0.0f);
        this.damageVignetteSprite.GetComponentInChildren<Image>().canvasRenderer.SetAlpha(0.0f);
        UpdateSpriteSize(screenSize);
	}

    private void UpdateSpriteSize(Vector2 size)
    {
        damageVignetteSprite.GetComponentInChildren<RectTransform>().sizeDelta = size;
        powerupVignetteSprite.GetComponentInChildren<RectTransform>().sizeDelta = size;
    }

    public void StartVignetteEffect(EffectType type)
    {
        //switch (type)
        switch (type)
        {
            case EffectType.DAMAGE:
                {
                    damageVignetteSprite.GetComponentInChildren<Image>().canvasRenderer.SetAlpha(1.0f);
                    damageVignetteSprite.GetComponentInChildren<Image>().CrossFadeAlpha(0.0f, f_Duration, false);
                    break;
                }
            case EffectType.POWERUP:
                {
                    powerupVignetteSprite.GetComponentInChildren<Image>().canvasRenderer.SetAlpha(1.0f);
                    powerupVignetteSprite.GetComponentInChildren<Image>().CrossFadeAlpha(0.0f, f_Duration, false);
                    break;
                }
        }

        this.effectEnabled = true;
        
    }


	
	// Update is called once per frame
    void Update()
    {
        if (Screen.width != screenSize.x || Screen.height != screenSize.y)
        {
            UpdateSpriteSize(new Vector2(Screen.width, Screen.height));
        }

    }
}
