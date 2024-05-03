using System.Collections;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private ScoreView _scoreView;

    private int _currentScore = 0;
    private bool _isActive = false;
    private Coroutine _counting;

    public void SwitchActive()
    {
        if (!_isActive)
        {
            _counting = StartCoroutine(Counting());
        }
        else
        {
            StopCoroutine(_counting);
        }

        _isActive = !_isActive;
    }

    IEnumerator Counting()
    {
        while (true)
        {
            _currentScore += 1;
            Debug.Log(_currentScore);
            _scoreView.ShowCurrentScore(_currentScore);
            yield return new WaitForSeconds(_delay);
        }
    }
}
