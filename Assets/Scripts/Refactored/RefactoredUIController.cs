using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefactoredUIController : UIControllerBase
{
    protected override GameControllerBase GameController => RefactoredGameController.Instance;

    public RefactoredUIController() : base()
    {
        // Coloca aquí el código necesario para la inicialización de RefactoredUIController
        RefactoredGameController.Instance.OnGameOver += HandleGameOver;
        RefactoredGameController.Instance.OnArrowShot += HandleArrowShot;
        UpdateUI();
    }

    private void UpdateUI()
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
    }

    private void HandleGameOver()
    {
        // Mostrar el overlay de Game Over.
        if (gameOverGroup != null)
        {
            gameOverGroup.SetActive(true);
        }
    }

    private void HandleArrowShot()
    {
        // Actualizar la UI después de que el jugador dispare una flecha.
        UpdateUI();
    }
}
