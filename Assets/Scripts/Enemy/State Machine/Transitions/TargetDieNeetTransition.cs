using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDieNeetTransition : Transition
{
    private void Update()
    {
        if(Target == null)
        {
            NeedTransit = true;
        }
    }
}
