using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGun : Gun
{
    public override void Shoot(bool facingRight)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + FireRate;

            GameObject bullet = Instantiate(BulletPrefab, ShootingPoint.position, BulletPrefab.transform.rotation) as GameObject;

            if (!facingRight)
            {
                Vector3 scaler = bullet.transform.localScale;
                scaler.y *= -1;
                bullet.transform.localScale = scaler;
            }

            bullet.GetComponent<BubbleBullet>().Shoot(facingRight);
        }
    }
}
