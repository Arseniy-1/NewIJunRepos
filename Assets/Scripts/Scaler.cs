using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private void OnEnable()
    {
        _cube.OnCubeSeparated += RescaleWithChance;
    }

    private void OnDisable()
    {
        _cube.OnCubeSeparated -= RescaleWithChance;
    }

    public void RescaleWithChance()
    {
        var random = Random.Range(0, 101);

        if (_cube.SeparationChance < random)
        {
            Destroy(gameObject);
        }

        transform.localScale /= 2;
    }
}
