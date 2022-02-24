using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyFlying : Enemy
{

    public void Release(EnemyBehavior enemy, ObjectPooler objectPooler)
    {
        objectPooler.GetFlyingPool().Release(enemy);
    }

    public void Get(ObjectPooler objectPooler)
    {
        objectPooler.GetFlyingPool().Get();
    }

}
