using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("Bullet damage")]
    [SerializeField] int damage = 10;
    public int Damage => damage;
}
