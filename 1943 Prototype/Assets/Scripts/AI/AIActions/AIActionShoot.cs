using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionShoot : AIAction
{
    public string weaponName;
    public bool waitRandomly;
    public float minWaitTime;
    public float maxWaitTime;

    float timeLeft;

    ICharacterWeapon characterWeapon;

    protected override void Initialization()
    {
        characterWeapon = GetComponent<ICharacterWeapon>();
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        timeLeft = Random.Range(minWaitTime, maxWaitTime);
    }

    public override void PerformAction()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft >= 0 && waitRandomly)
        {
            return;
        }
        timeLeft = Random.Range(minWaitTime, maxWaitTime);
        characterWeapon.ProcessWeapon(weaponName);
    }
}
