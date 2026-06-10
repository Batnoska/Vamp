using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Event Channels/Enemy Death")]
public class EnemyDeathEventChannelSO : ScriptableObject
{
    public Action<Enemy> OnEventRaised;

    public void RaiseEvent(Enemy enemy)
    {
        OnEventRaised?.Invoke(enemy);
    }
}
