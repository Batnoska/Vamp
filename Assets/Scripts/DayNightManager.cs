using UnityEngine;
using UnityEngine.InputSystem;

public class DayNightManager : MonoBehaviour
{
    [SerializeField] EnemySpawner spawner;

    [SerializeField] EnemyFactorySO dayFactory;

    [SerializeField] EnemyFactorySO nightFactory;

    bool isNight;

    void Update()
    {
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            ToggleDayNight();
        }
    }

    void ToggleDayNight()
    {
        isNight = !isNight;

        spawner.SetFactory(
            isNight ? nightFactory : dayFactory
        );
    }
}
