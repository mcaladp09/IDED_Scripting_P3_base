using UnityEngine;

public class UIController : UIControllerBase
{
    [SerializeField]
    private GameController gameController;

    protected override GameControllerBase GameController => gameController;

    // Update is called once per frame
    private void Update()
    {
        if (GameController != null)
        {
            if (shotsCountLabel != null)
            {
                shotsCountLabel.text = GameController.RemainingArrows.ToString();
            }

            if (scoreCountLabel != null)
            {
                scoreCountLabel.text = GameController.Score.ToString();
            }

            if (windLabel != null)
            {
                windLabel.text = string.Format("{0:0.00F}", GameController.WindSpeed);
            }

            if (GameController.RemainingArrows < 1)
            {
                gameOverGroup?.SetActive(true);
                enabled = false;
            }
        }
    }
}