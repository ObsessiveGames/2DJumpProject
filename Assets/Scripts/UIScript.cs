using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    public static UIScript Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        scoreText.text = "Score: " + PlayerController.Instance.Score;
        livesText.text = "Lives: " + PlayerController.Instance.Lives;
    }
}