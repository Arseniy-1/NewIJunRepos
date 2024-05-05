using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Cube _cube;
    [SerializeField] private int _maxCubesCount = 6;
    [SerializeField] private int _minCubesCount = 2;

    private float _explosionFactor;

    private void OnEnable()
    {
        _explosionFactor = 1 / transform.localScale.x;
        _cube.OnCubeSeparated += CreateExplode;
    }

    private void OnDisable()
    {
        _cube.OnCubeSeparated -= CreateExplode;
    }

    private void CreateExplode()
    {
        CreateObject();
        Explode();
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            explodableObject.AddExplosionForce(_explosionForce * _explosionFactor, transform.position, _explosionRadius * _explosionFactor);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius * _explosionFactor);

        List<Rigidbody> barrels = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                barrels.Add(hit.attachedRigidbody);
            }
        }

        return barrels;
    }

    private void CreateObject()
    {
        int CubeCount = Random.Range(_minCubesCount, _maxCubesCount + 1);

        for (int i = 0; i < CubeCount; i++)
        {
            GameObject cube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
        }
    }
}
