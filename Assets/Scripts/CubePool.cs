using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour, CubeReturner
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

    public bool TryGetCube(out Cube cube)
    {
        if( _cubes.Count == 0)
        {
            cube = null;
            return false;
        }

        cube = _cubes.Dequeue();
        cube.gameObject.SetActive(true);

        return true;
    }

    public void ReturnCube(Cube cube)
    {
        cube.gameObject.SetActive(false);
        _cubes.Enqueue(cube);
    }
}
