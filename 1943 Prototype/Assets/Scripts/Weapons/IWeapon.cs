public interface IWeapon
{
    void Shoot();
    string WeaponName();
    void Init(ICharacterWeapon character);
}
