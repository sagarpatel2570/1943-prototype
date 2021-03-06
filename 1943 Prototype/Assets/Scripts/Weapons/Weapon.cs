﻿using UnityEngine;

public enum WeaponState
{
    IDLE,
    READY,
    SHOOT,
    COOLDOWN,
    RELOAD,
    OUTOFAMMO,
}

public class Weapon : MonoBehaviour,IWeapon
{
    public GameObject ammoPrefab;
    public Transform ammoSpawnPoint;
    public WeaponState currentWeaponState;
    public string weaponName;
    public int ammo;
    public int magzineQty;
    public float reloadTime;
    public float weaponCoolDownTime;
    public bool infiniteAmmo;

    protected int ammoLeftInMagzine;
    protected int currentAmmoLeft;
    protected float currentReloadTime;
    protected float cooldownTimeLeft;

    protected ICharacterWeapon owner;

    void OnEnable()
    {
        Init();
    }

    public virtual void Init()
    {
        currentAmmoLeft = ammo;
        ammoLeftInMagzine = magzineQty;
        currentReloadTime = reloadTime;
        cooldownTimeLeft = weaponCoolDownTime;
    }

    public virtual void DeInit ()
    {
        
    }

    protected virtual void Update()
    {
        switch (currentWeaponState)
        {
            case WeaponState.IDLE:
                WeaponIdle();
                break;
            case WeaponState.SHOOT:
                WeaponShoot();
                break;
            case WeaponState.COOLDOWN:
                WeaponCoolDown();
                break;
            case WeaponState.RELOAD:
                WeaponReload();
                break;
        }
    }

    protected virtual void WeaponIdle()
    {
        currentWeaponState = WeaponState.READY;
    }

    protected virtual void WeaponShoot()
    {
        currentWeaponState = WeaponState.COOLDOWN;
    }
    protected virtual void WeaponCoolDown()
    {
        cooldownTimeLeft -= Time.deltaTime;
        if(cooldownTimeLeft <= 0)
        {
            cooldownTimeLeft = weaponCoolDownTime;
            currentWeaponState = WeaponState.READY;
        }
    }

    protected virtual void WeaponReload()
    {
        currentReloadTime -= Time.deltaTime;
        if(currentReloadTime <= 0)
        {
            currentReloadTime = reloadTime;
            if (!infiniteAmmo)
            {
                int ammoTOAdd = 0;
                if (currentAmmoLeft > magzineQty)
                {
                    currentAmmoLeft -= magzineQty;
                    ammoTOAdd = magzineQty;
                }
                else
                {
                    ammoTOAdd = currentAmmoLeft;
                    currentAmmoLeft = 0;
                }
                ammoLeftInMagzine = ammoTOAdd;
            }
            else
            {
                ammoLeftInMagzine = magzineQty;
            }

            if(ammoLeftInMagzine > 0)
            {
                currentWeaponState = WeaponState.READY;
            }
            else
            {
                currentWeaponState = WeaponState.OUTOFAMMO;
                owner.RemoveWeapon(this);
                Destroy(gameObject);
            }
        }
    }

    public virtual void Shoot()
    {
        if (currentWeaponState == WeaponState.READY)
        {
            currentWeaponState = WeaponState.SHOOT;
        }
    }

    public virtual string WeaponName()
    {
        return weaponName;
    }

    public virtual void Init(ICharacterWeapon character)
    {
        owner = character;
    }

    public virtual void AimWeapon(Vector3 dir)
    {
        transform.up = dir;
    }

    public void DestroyWeapon()
    {
        Destroy(gameObject);
    }
}
