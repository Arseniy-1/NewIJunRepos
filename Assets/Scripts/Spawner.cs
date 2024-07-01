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
        var delay = new WaitForSeconds(_spawnDelay);

        while (true)
        {
            yield return delay;
            Vector3 randomPosition = _positions[Random.Range(0, _positions.Count)];

            Cube cube = _cubePool.Get();
            cube.transform.position = randomPosition;
            //if (_cubePool.TryGet(out Cube cube))
            //    cube.transform.position = randomPosition;
        }
    }
}
