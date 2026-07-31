using UnityEngine;

public class LightingController : MonoBehaviour
{
    public Light[] houseLights;      // drag all room lights here
    public bool lightsOn = false;    //default to false

    [Header("Optional flicker effect")]
    public bool useFlickerOnToggle = false;
    public float flickerDuration = 1.5f;

    public void ToggleLights()
    {
        lightsOn = !lightsOn;

        if (useFlickerOnToggle && !lightsOn)
            StartCoroutine(FlickerThenOff());
        else
            SetLights(lightsOn);
    }
    
    void Start() {
        SetLights(lightsOn); // Force lights to match the flag when scene starts
    }

    void SetLights(bool state)
    {
        foreach (Light l in houseLights)
        {
            if (l != null) l.enabled = state;
        }
    }

    System.Collections.IEnumerator FlickerThenOff()
    {
        float t = 0;
        while (t < flickerDuration)
        {
            SetLights(Random.value > 0.5f);
            t += Random.Range(0.05f, 0.2f);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));
        }
        SetLights(false);
    }
}

