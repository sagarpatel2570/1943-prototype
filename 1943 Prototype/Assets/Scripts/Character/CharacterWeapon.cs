﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface ICharacterWeapon
{
    void RemoveWeapon(IWeapon weapon);
    void AddWeapon(IWeapon weapon);
    void ProcessWeapon(string weaponName);
    void AimWeapon(Vector3 dir);
}

public class CharacterWeapon : CharacterAbility,ICharacterWeapon
{
    public Transform primaryWeaponTransform;
    public Transform secondaryWeaponTransform;

    public GameObject primaryWeaponGo;
    public GameObject secondaryWeaponGo;

    IWeapon primaryWeapon;
    IWeapon secondaryWeapon;

    public void AddWeapon(IWeapon weapon)
    {
        
    }

    public void RemoveWeapon(IWeapon weapon)
    {
        if (secondaryWeapon == weapon)
        {
            secondaryWeapon = null;
        }
    }

    public void RemoveSecondaryWeapon()
    {
        if (secondaryWeapon != null)
        {
            secondaryWeapon.DestroyWeapon();
        }
    }

    public void AddSecondaryWeapon(GameObject prefab)
    {
        GameObject weapon = Instantiate(prefab, transform.position, Quaternion.identity);
        weapon.transform.SetParent(secondaryWeaponTransform);
        weapon.transform.localPosition = Vector3.zero;
        secondaryWeapon = weapon.GetComponent<IWeapon>();
        secondaryWeapon.Init(this);
    }

    public override void Init()
    {
        base.Init();

        IWeapon[] weapons = GetComponentsInChildren<IWeapon>();

        if(primaryWeaponGo != null)
        {
            GameObject weapon = Instantiate(primaryWeaponGo, transform.position,Quaternion.identity);
            weapon.transform.SetParent(primaryWeaponTransform);
            weapon.transform.localPosition = Vector3.zero;
            primaryWeapon = weapon.GetComponent<IWeapon>();
            primaryWeapon.Init(this);
        }

        if (secondaryWeaponGo != null)
        {
            AddSecondaryWeapon(secondaryWeaponGo);
        }
    }

    protected override void HandleInput()
    {
        if(!character.isPlayer)
        {
            return;
        }

        if(Input.GetMouseButton(0) && primaryWeapon != null)
        {
            primaryWeapon.Shoot();
        }

        if (Input.GetMouseButton(1) && secondaryWeapon != null)
        {
            secondaryWeapon.Shoot();
        }
    }

    public void ProcessWeapon(string weaponName)
    {
        
    }

    public void AimWeapon(Vector3 dir)
    {

    }
}
