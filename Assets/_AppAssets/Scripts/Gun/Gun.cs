﻿using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected Transform ShootingPoint;
    [SerializeField] protected GameObject BulletPrefab;
    [SerializeField] protected float FireRate;

    protected float nextFire;


    public virtual void Shoot(bool facingRight) {}
}
