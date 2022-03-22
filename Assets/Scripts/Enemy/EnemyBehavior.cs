using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyBehavior : MonoBehaviour
{
    [Tooltip("Enemy damage")]
    [SerializeField] int damage = 10;

    [Tooltip("Enemy move speed")]
    [SerializeField] float moveSpeed;

    [Tooltip("Distance to stop before reaching target")]
    [SerializeField] float stoppingDistance;
    public int Damage => damage;

    [SerializeField] EnemyType enemyType;
    [SerializeField] Enemy currentBehavior = new EnemyGround();

    ObjectPooler objectPooler;
    Transform targetTransform;
    Rigidbody myRigidBody;

    void Awake() 
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        targetTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    void FixedUpdate() 
    {
        Vector3 moveTowards = currentBehavior.FollowTarget(transform, targetTransform, stoppingDistance, moveSpeed);
        myRigidBody.MovePosition(moveTowards);
    }

    public void Init(ObjectPooler objectPooler) 
    {
        switch (enemyType)
        {
            case EnemyType.Ground:
            currentBehavior = new EnemyGround();
            break;

            case EnemyType.Flying:
            currentBehavior = new EnemyFlying();
            break;
        }
        this.objectPooler = objectPooler;
    }

    public void ReleaseEnemy()
    {
        currentBehavior.Release(this, objectPooler, enemyType);
    }

    public void GetFromPool()
    {
        currentBehavior.Get(objectPooler, enemyType);
    }
}
