using UnityEngine;

public class Painter : MonoBehaviour
{
    [SerializeField] private Material[] _materials;
    [SerializeField] private MeshRenderer _meshRenderer;

    private void OnEnable()
    {
        PaintObject();
    }

    private void PaintObject()
    {
        _meshRenderer.material = _materials[Random.Range(0, _materials.Length)];
    }
}
