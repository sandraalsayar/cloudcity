using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkyBox : MonoBehaviour
{
    public Material skybox;
    public float step = 0;
    public Light directionalLight;
    private Color dayColor;
    private Color nightColor;
    private float dayLightIntensity;
    private float nightLightIntensity;
    private float duration;

    // Start is called before the first frame update
    void Start()
    {
        dayColor = new Color(0.7137f, 0.7137f, 0.5647f);
        nightColor = new Color(0.1568f, 0.18039f, 0.2196f);
        dayLightIntensity = 1.2f;
        nightLightIntensity = 0.75f;
        duration = 30f;
   

    }

    private void Update()
    {
        RenderSettings.skybox.SetColor("_TintColor", Color.Lerp(dayColor, nightColor, step));
        directionalLight.intensity = Mathf.Lerp(dayLightIntensity, nightLightIntensity, step);
        DynamicGI.UpdateEnvironment();
        step += Time.deltaTime / duration;

    }

    void OnDisable()
    {
        RenderSettings.skybox.SetColor("_TintColor", dayColor);
        DynamicGI.UpdateEnvironment();
    }

}
