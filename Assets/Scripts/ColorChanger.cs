using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;
    private MeshRenderer _meshRenderer;

    public void ChangeColor()
    {
        _meshRenderer.material = _materials[Random.Range(0, _materials.Count)];
    }

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
}
