using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : CharacterAbility
{
    public Transform weaponTransformParent;
    public GameObject initialWeapon;

    IWeapon weapon;

    public override void Init()
    {
        base.Init();
        if(initialWeapon != null)
        {
            GameObject weapon = Instantiate(initialWeapon,transform.position,Quaternion.identity);
            weapon.transform.parent = weaponTransformParent;
            Init(weapon.GetComponent<IWeapon>());
        }
    }

    public void Init(IWeapon weapon)
    {
        this.weapon = weapon;
    }

    protected override void HandleInput()
    {
        if(Input.GetMouseButton(0))
        {
            weapon.Shoot();
        }
    }
}
