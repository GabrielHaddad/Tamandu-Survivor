using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy
{
    void Release(EnemyBehavior enemy, ObjectPooler objectPooler);
    void Get(ObjectPooler objectPooler);
}
