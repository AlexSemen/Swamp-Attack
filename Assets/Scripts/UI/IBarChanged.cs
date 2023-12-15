using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IBarChanged
{
    public event UnityAction<int, int> BarChanged;
}
