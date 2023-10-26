using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private Text shotsCountLabel, scoreCountLabel, windLabel;

    [SerializeField]
    private GameObject gameOverGroup, windDirectionIndicator;

    // Start is called before the first frame update
    private void Start()
    {
        if (shotsCountLabel == null ||
            scoreCountLabel == null ||
            windLabel == null ||
            windDirectionIndicator == null ||
            gameController == null)
        {
            print("Something is null");
            enabled = false;
        }

        gameOverGroup?.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameController != null)
        {
            if (shotsCountLabel != null)
            {
                shotsCountLabel.text = gameController.RemainingArrows.ToString();
            }

            if (scoreCountLabel != null)
            {
                scoreCountLabel.text = gameController.Score.ToString();
            }

            if (windLabel != null)
            {
                windLabel.text = string.Format("{0:0.00F}", gameController.WindSpeed);
            }

            if (gameController.RemainingArrows < 1)
            {
                gameOverGroup?.SetActive(true);
                enabled = false;
            }
        }
    }
}