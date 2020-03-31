using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalWeapon : Weapon
{
    protected override void WeaponShoot()
    {
        base.WeaponShoot();
        GameObject ammo = SimplePool.Spawn(ammoPrefab, ammoSpawnPoint.position, Quaternion.identity);
        ammo.transform.up = ammoSpawnPoint.up;
        ammoLeftInMagzine--;
        if(ammoLeftInMagzine <=0)
        {
            currentWeaponState = WeaponState.RELOAD;
        }
    }
}
