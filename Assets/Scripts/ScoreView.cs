using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void ShowCurrentScore(int score)
    {
        _scoreText.text = score.ToString();
    }
}
