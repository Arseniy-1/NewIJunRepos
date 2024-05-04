using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _maxExplosionForce;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Cube _cube;
    [SerializeField] private int _maxCubesCount = 6;
    [SerializeField] private int _minCubesCount = 2;

    private void OnEnable()
    {
        _cube.OnCubeSeparated += ObjectCreator;
    }

    private void OnDisable()
    {
        _cube.OnCubeSeparated -= ObjectCreator;
    }


    private void ObjectCreator()
    {
        int CubeCount = Random.Range(_minCubesCount, _maxCubesCount + 1);

        for (int i = 0; i < CubeCount; i++)
        {
            GameObject cube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
            cube.GetComponent<Scaler>().RescaleWithChance();
            cube.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0, _maxExplosionForce), Random.Range(0, _maxExplosionForce), Random.Range(0, _maxExplosionForce)), ForceMode.Impulse);
        }
    }
}
