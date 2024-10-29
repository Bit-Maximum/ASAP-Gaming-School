using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightManager : MonoBehaviour
{
    private Light2D globalLight;

    [SerializeField] private Color defaultGamma; 
    [SerializeField] private Color dungerGamma; 

    private void Awake()
    {
        globalLight = GetComponent<Light2D>();
    }

    public void SetDungerGamma()
    {
        globalLight.color = dungerGamma;
    }

    public void ResetGamma()
    {
        globalLight.color = defaultGamma;
    }
}
