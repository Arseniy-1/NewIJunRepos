using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private List<Vector3> _positions;
    [SerializeField] private float _spawnDelay = 1.0f;

    private System.Random _random = new System.Random();

    private void Start()
    {
        StartCoroutine(SpawningCubes());
    }

    private IEnumerator SpawningCubes()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);
            Vector3 randomPosition = _positions[_random.Next(_positions.Count)];

            if (_cubePool.TryGetCube(out Cube cube))
                cube.transform.position = randomPosition;
        }
    }
}
