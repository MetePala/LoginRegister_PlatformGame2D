using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public interface IMover
{
    public float Horizontal { get; }
    public float Vertical { get; }
    public float Jump { get; }

}
