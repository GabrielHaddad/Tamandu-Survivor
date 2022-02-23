using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    private IObjectPool<Enemy> enemyPool;

    public void SetPool(IObjectPool<Enemy> pool)
    {
        enemyPool = pool;
    }

    public IObjectPool<Enemy> GetPool()
    {
        return enemyPool;
    }

}
