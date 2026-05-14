using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DayNightManager : MonoBehaviour
{
    [SerializeField] EnemySpawner spawner;

    [SerializeField] EnemyFactorySO dayFactory;

    [SerializeField] EnemyFactorySO nightFactory;

    bool isNight;

    // void Update()
    // {
    //     if (Keyboard.current.kKey.wasPressedThisFrame)
    //     {
    //         ToggleDayNight();
    //     }
    // }

    private void OnEnable()
    {
        GameTimer.Instance.OnNightStarted += ToggleDayNight;
    }

    private void OnDisable()
    {
        GameTimer.Instance.OnNightStarted -= ToggleDayNight;
    }

    void ToggleDayNight()
    {
        isNight = !isNight;

        spawner.SetFactory(
            isNight ? nightFactory : dayFactory
        );
    }
}
