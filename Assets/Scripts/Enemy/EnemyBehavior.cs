using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyBehavior : MonoBehaviour
{
    [Tooltip("Distance to stop before reaching target")]
    [SerializeField] float stoppingDistance;

    [SerializeField] EnemyType enemyType;
    [SerializeField] Enemy currentBehavior = new EnemyGround();

    float moveSpeed;
    int damage = 10;
    public int Damage => damage;

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
        EnemyFollowTarget();
    }

    void EnemyFollowTarget()
    {
        float distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);
        if (distanceToTarget <= stoppingDistance) return;

        Vector3 moveTowards = currentBehavior.FollowTarget(transform, targetTransform, moveSpeed);
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

    public void SetEnemySpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void SetEnemyDamage(int damage)
    {
        this.damage = damage;
    }

    public void ReleaseEnemy()
    {
        currentBehavior.Release(this, objectPooler, enemyType);
    }

    public EnemyBehavior GetFromPool()
    {
        return currentBehavior.Get(objectPooler, enemyType);
    }
}
