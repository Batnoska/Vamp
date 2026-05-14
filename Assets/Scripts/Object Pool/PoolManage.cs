using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManage : MonoBehaviour
{
    public static PoolManage Instance;

    private Dictionary<GameObject, IObjectPool<GameObject>> pools =
        new Dictionary<GameObject, IObjectPool<GameObject>>();

    private void Awake()
    {
        Instance = this;
    }

    public GameObject Get(GameObject prefab)
    {
        if (!pools.ContainsKey(prefab))
        {
            pools[prefab] = CreatePool(prefab);
        }

        return pools[prefab].Get();
    }

    public void Release(GameObject obj, GameObject prefab)
    {
        if (!pools.ContainsKey(prefab)) return;
        
        pools[prefab].Release(obj);
    }
    
    private IObjectPool<GameObject> CreatePool(GameObject prefab)
    {
        return new ObjectPool<GameObject>(
            () => Instantiate(prefab),
            obj => obj.SetActive(true),
            obj => obj.SetActive(false),
            obj => Destroy(obj),
            true,
            10,
            30
        );
    }
}
