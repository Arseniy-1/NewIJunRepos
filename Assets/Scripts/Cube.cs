using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action OnCubeSeparated;

    public float SeparationChance { get; private set; } = 100f;

    private void OnMouseUpAsButton()
    {
        OnCubeSeparated?.Invoke();
        SeparationChance /= 2;
    }
}
