using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private const string SCORE_TAG = "ScoreArea";
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private int score;

    private void AddScore()
    {
        score++;
        scoreText.SetText(score.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag(SCORE_TAG))
        {
            AddScore();
            collider.enabled = false;
        }
    }
}