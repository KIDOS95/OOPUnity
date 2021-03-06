using TMPro;
using UnityEngine;

public class NumberPoints : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    [SerializeField] private Scores scores;
    [SerializeField] private int score;
    [SerializeField] private int maxScore;


    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

        switch (scores)
        {
            case Scores.MaxScore:

                JsonController.LoadField();
                score = JsonController.item.RecordPoints;
                textMesh.text = score.ToString();

                break;

            case Scores.Scoring:

                Enemy.onEnemyDestroy += EnemyDestroyed;
                Player.onPlayerDestroy += SevingPoints;

                break;
        }
    }

    private void OnDisable()
    {
        Enemy.onEnemyDestroy -= EnemyDestroyed;
        Player.onPlayerDestroy -= SevingPoints;
    }

    private void EnemyDestroyed()
    {
        score++;
        textMesh.text = score.ToString();
    }

    private void SevingPoints()
    {
        JsonController.LoadField();
        maxScore = JsonController.item.RecordPoints;
        if (score >= maxScore)
        {
            JsonController.item.RecordPoints = score;
            JsonController.SaveField();
        }
    }
}

public enum Scores
{
    Scoring,
    MaxScore
}
