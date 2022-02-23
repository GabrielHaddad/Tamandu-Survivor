using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    [Tooltip("Enemy damage")]
    [SerializeField] int damage = 10;
    public int Damage => damage;

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
