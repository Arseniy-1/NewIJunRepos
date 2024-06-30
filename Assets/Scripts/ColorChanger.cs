using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;
    private MeshRenderer _meshRenderer;
    private System.Random _random = new System.Random();

    public void ChangeColor()
    {
        _meshRenderer.material = _materials[_random.Next(_materials.Count)];
    }

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
}
