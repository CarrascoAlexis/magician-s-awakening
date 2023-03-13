using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleManagement : MonoBehaviour
{
    public Light sun;
    [SerializeField] private float secondsInFullDay;
    [Range(0, 1)]
    public float currentTimeOfDay = 0;

    void Update()
    {
        UpdateSun();
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay);
        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
    }
}
