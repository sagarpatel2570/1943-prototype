using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionShootAtTarget : AIAction
{
    public override void PerformAction()
    {
        if(brain.target == null)
        {
            return;
        }

        ICharacterWeapon characterWeapon = GetComponent<ICharacterWeapon>();
        if(characterWeapon !=  null)
        {
            characterWeapon.AimWeapon(brain.target.position - transform.position);
        }
    }
}
