using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action OnCubeSeparated;

    private int _chanceDivider = 2;
    private int _maxRandomNumber = 100;

    public float SeparationChance { get; private set; } = 100f;

    private void OnMouseUpAsButton()
    {
        var random = UnityEngine.Random.Range(0, _maxRandomNumber + 1);

        if (SeparationChance > random)
        {
            OnCubeSeparated?.Invoke();
            SeparationChance = SeparationChance / _chanceDivider;
        }

        Destroy(gameObject);
    }
}
