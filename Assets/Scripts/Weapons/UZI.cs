using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UZI : Weapon
{
    private void Awake()
    {
        boolParameterAnimator = AnimatorPlayer.Bool.UZI;
    }

    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint);
    }
}
