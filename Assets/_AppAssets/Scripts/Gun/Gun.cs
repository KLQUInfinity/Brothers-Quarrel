using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public Transform ShootingPoint;
    public GameObject BulletPrefab;
    public float FireRate;


    public virtual void Shoot(){}
}
