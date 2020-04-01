using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapon : Weapon
{
    public Transform[] ammoSpawnPoints;

    protected override void WeaponShoot()
    {
        base.WeaponShoot();
        for (int i = 0; i < ammoSpawnPoints.Length; i++)
        {
            GameObject ammo = SimplePool.Spawn(ammoPrefab, ammoSpawnPoints[i].position, Quaternion.identity);
            ammo.transform.up = ammoSpawnPoints[i].up;
            ammoLeftInMagzine--;
            if (ammoLeftInMagzine <= 0)
            {
                currentWeaponState = WeaponState.RELOAD;
                return;
            }
        }
    }
}
