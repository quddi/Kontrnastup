using UnityEngine;
using TMPro;

public class RecordVisualizer : MonoBehaviour
{
    [SerializeField] private TMP_Text _bestScoreText;

    private const string BestScorePrefix = "Рекорд: ";

    private void Start()
    {
        Visualize();
    }

    private void Visualize()
    {
        _bestScoreText.text = BestScorePrefix + DataResponsable.PlayerData.BestScore.ToString();
    }
}
