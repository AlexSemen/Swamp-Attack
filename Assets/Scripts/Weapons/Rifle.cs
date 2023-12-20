using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    private void Awake()
    {
        boolParameterAnimator = AnimatorPlayer.Bool.Rifle;
    }

    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint);
    }
}
