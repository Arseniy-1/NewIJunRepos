using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private List<Vector3> _positions;
    [SerializeField] private float _spawnDelay = 1.0f;

    private void Start()
    {
        StartCoroutine(SpawningCubes());
    }

    private IEnumerator SpawningCubes()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);
            Vector3 randomPosition = _positions[Random.Range(0, _positions.Count)];

            if (_cubePool.TryGetCube(out Cube cube))
                cube.transform.position = randomPosition;
        }
    }
}
