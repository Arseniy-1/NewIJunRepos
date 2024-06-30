using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField]private ColorChanger _colorChanger;
    private CubeReturner _cubeReturner;
    private bool _isTouched;
    private int _maxDelay = 5;
    private int _minDelay = 2;

    public void Initialize(CubeReturner cubeReturner)
    {
        _cubeReturner = cubeReturner;
    }

    private void OnEnable()
    {
        _isTouched = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            if (_isTouched)
                return;

            _colorChanger.ChangeColor();
            _isTouched = true;
            StartCoroutine(DestroingCubeWithDelay());
        }
    }

    private IEnumerator DestroingCubeWithDelay()
    {
        yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
        _cubeReturner.ReturnCube(this);
    }
}
