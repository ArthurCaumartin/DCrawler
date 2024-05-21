using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public override void Shoot(Transform holderTransform = null)
    {
        base.Shoot(holderTransform);
        GameObject newBullet = Instantiate(_bulletPrefabs, holderTransform.position, transform.rotation);
    }
}
