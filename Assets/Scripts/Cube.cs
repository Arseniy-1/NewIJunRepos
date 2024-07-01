using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private Painter _painter;
    private ICubeReturner _cubeReturner;
    private bool _isTouched;
    private int _maxDelay = 5;
    private int _minDelay = 2;

    public void Initialize(ICubeReturner cubeReturner)
    {
        _cubeReturner = cubeReturner;
    }

    private void OnEnable()
    {
        _isTouched = false;
        _painter.ChangeToDefaultColor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            if (_isTouched)
                return;

            _painter.ChangeColor();
            _isTouched = true;
            StartCoroutine(DestroingWithDelay());
        }
    }

    private IEnumerator DestroingWithDelay()
    {
        yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
        _cubeReturner.Return(this);
    }
}
