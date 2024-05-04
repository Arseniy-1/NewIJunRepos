using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    [SerializeField] private Material[] _materials;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Cube _cube;

    private void OnEnable()
    {
        PaintObject();
        _cube.OnCubeSeparated += PaintObject;
    }

    private void OnDisable()
    {
        _cube.OnCubeSeparated -= PaintObject;
    }

    private void PaintObject()
    {
        _meshRenderer.material = _materials[Random.Range(0, _materials.Length)];
    }
}
