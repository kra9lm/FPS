namespace Lession1
{
    public class Rifle : WeaponBase
    {
        public override void Fire(AmmunitionsBase ammunition)
        {
            if (!_CanFire) return;
            if (ammunition)
            {
                var tempAmmunition = Instantiate(ammunition, _barrel.position, _barrel.rotation);
                if (tempAmmunition)
                {
                    tempAmmunition.Rigidbody.AddForce(_barrel.forward * _force);
                    _CanFire = false;
                    _timer.Start(_cooldown );
                }
            }
            else
            {
                //raycasting
            }
        }
    }
}
