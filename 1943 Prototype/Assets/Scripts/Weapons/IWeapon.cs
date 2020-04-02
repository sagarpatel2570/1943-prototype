using UnityEngine;

public interface IWeapon
{
    void Shoot();
    string WeaponName();
    void Init(ICharacterWeapon character);
    void AimWeapon(Vector3 dir);
    void DestroyWeapon();
}
