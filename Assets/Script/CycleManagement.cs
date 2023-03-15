using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleManagement : MonoBehaviour
{
    private Light sun;
    [SerializeField] private float dayLength;
    [Range(0, 1)]
    [SerializeField] private float currentTimeOfDay;

    void Start()
    {
        sun = GetComponent<Light>();
    }

    void Update()
    {
        UpdateSun();
        currentTimeOfDay += (Time.deltaTime / dayLength);
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
