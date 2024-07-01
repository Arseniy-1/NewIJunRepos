using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour, ICubeReturner
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _poolCapacity;
    private Queue<Cube> _cubes = new Queue<Cube>();

    private void Awake()
    {
        for(int i = 0; i < _poolCapacity; i++)
            _cubes.Enqueue(Instantiate(_cubePrefab));

        foreach(Cube cube in _cubes)
        {
            cube.gameObject.SetActive(false);
            cube.Initialize(this);
        }
    }

    public Cube Get()
    {
        if (_cubes.Count == 0)
            ExpandPool();

        Cube newCube = _cubes.Dequeue();
        newCube.gameObject.SetActive(true);

        return newCube;
    }

    public void Return(Cube cube)
    {
        cube.gameObject.SetActive(false);
        _cubes.Enqueue(cube);
    }

    private void ExpandPool()
    {
        Cube cube = Instantiate(_cubePrefab);
        cube.Initialize(this);
        _cubes.Enqueue(cube);
    }
}
