using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ParryScript
{
    public void Deflect(Vector2 direction);
    public float returnSpeed {  get; set; }
    public bool IsParrying { get; set; }
}
