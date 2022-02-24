using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyGround : Enemy
{

    public void Release(EnemyBehavior enemy, ObjectPooler objectPooler)
    {
        objectPooler.GetGroundPool().Release(enemy);
    }

    public void Get(ObjectPooler objectPooler) 
    {
        objectPooler.GetGroundPool().Get();
    }

}
