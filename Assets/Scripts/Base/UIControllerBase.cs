using UnityEngine;
using UnityEngine.UI;

public abstract class UIControllerBase : MonoBehaviour
{
    [SerializeField]
    protected Text shotsCountLabel, scoreCountLabel, windLabel;

    [SerializeField]
    protected GameObject gameOverGroup, windDirectionIndicator;

    protected abstract GameControllerBase GameController { get; }

    // Start is called before the first frame update
    private void Start()
    {
        if (shotsCountLabel == null ||
            scoreCountLabel == null ||
            windLabel == null ||
            windDirectionIndicator == null)
        {
            print("Something is null");
            enabled = false;
        }

        gameOverGroup?.SetActive(false);
    }
}