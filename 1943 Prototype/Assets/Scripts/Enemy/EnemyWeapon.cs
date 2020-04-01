using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyWeapon : CharacterAbility,ICharacterWeapon
{
    Dictionary<string,IWeapon> weaponsNameDic = new Dictionary<string, IWeapon>();

    public void AddWeapon(IWeapon weapon)
    {

    }

    public void RemoveWeapon(IWeapon weapon)
    {
       
    }

    public override void Init()
    {
        base.Init();
        List<IWeapon> weapons = GetComponentsInChildren<IWeapon>().ToList();
        for (int i = 0; i < weapons.Count; i++)
        {
            weaponsNameDic.Add(weapons[i].WeaponName(), weapons[i]);
        }
    }

    public override void DeInit()
    {
        base.DeInit();
        weaponsNameDic.Clear();
    }

    public void ProcessWeapon(string weaponName)
    {
        weaponsNameDic[weaponName].Shoot();
    }
}
