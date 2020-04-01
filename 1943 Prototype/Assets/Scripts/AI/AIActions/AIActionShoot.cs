using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionShoot : AIAction
{
    public string weaponName;
    ICharacterWeapon characterWeapon;

    protected override void Initialization()
    {
        characterWeapon = GetComponent<ICharacterWeapon>();
    }

    public override void PerformAction()
    {
        characterWeapon.ProcessWeapon(weaponName);
    }
}
