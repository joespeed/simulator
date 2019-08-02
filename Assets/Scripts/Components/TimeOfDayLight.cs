/**
 * Copyright (c) 2019 LG Electronics, Inc.
 *
 * This software contains code licensed as described in LICENSE.
 *
 */

using UnityEngine;
using System.Collections;

public class TimeOfDayLight : MonoBehaviour
{
    private Light streetLight;
    private Renderer lightMesh;
    
    public void Init(TimeOfDayStateTypes state)
    {
        streetLight = GetComponentInChildren<Light>();
        lightMesh = GetComponent<Renderer>();
        SimulatorManager.Instance.EnvironmentEffectsManager.TimeOfDayChanged += OnTimeOfDayChange;
        OnTimeOfDayChange(state);
    }
    
    private void OnTimeOfDayChange(TimeOfDayStateTypes state)
    {
        switch (state)
        {
            case TimeOfDayStateTypes.Day:
                ToggleLight(false);
                SetMeshEmissiveColor(Color.black);
                break;
            case TimeOfDayStateTypes.Night:
                ToggleLight(true);
                SetMeshEmissiveColor(Color.white * 2f);
                break;
            case TimeOfDayStateTypes.Sunrise:
                ToggleLight(false);
                SetMeshEmissiveColor(Color.black);
                break;
            case TimeOfDayStateTypes.Sunset:
                ToggleLight(true);
                SetMeshEmissiveColor(Color.white * 2f);
                break;
        }
    }

    private void ToggleLight(bool state)
    {
        if (streetLight != null)
            streetLight.enabled = state;
    }

    private void SetMeshEmissiveColor(Color color, float hd = 1f)
    {
        if (lightMesh != null)
            lightMesh.material.SetVector("_EmissiveColor", color * hd);
    }
}
