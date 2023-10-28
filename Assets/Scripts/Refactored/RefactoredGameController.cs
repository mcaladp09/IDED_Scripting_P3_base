using UnityEngine;
using System.Collections;

public class RefactoredGameController : GameControllerBase
{
    private static RefactoredGameController instance;

    public static RefactoredGameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RefactoredGameController>();
            }
            return instance;
        }
    }

    private RefactoredPlayerController playerController;

    public override PlayerControllerBase PlayerController => playerController;

    public event System.Action OnGameOver;
    public event System.Action OnArrowShot;

    private bool gameIsOver = false;

    protected override void Awake()
    {
        base.Awake();
    }

    public void StartGame()
    {
        gameIsOver = false;
        Score = 0;
        StartCoroutine(GameLoop());
    }

    public void HandleArrowShot(Vector3 point)
    {
        OnArrowShot?.Invoke();
        RefactoredPlayerController.Instance.ProcessShot(point);
    }

    IEnumerator GameLoop()
    {
        while (playerController.ArrowCount > 0)
        {
            yield return StartCoroutine(ProcessTurn());
        }
        EndGame();
    }

    IEnumerator ProcessTurn()
    {
        yield return new WaitForSeconds(1f);
        OnArrowShot?.Invoke();
        playerController.ProcessShot(Vector3.zero);
        yield return new WaitForSeconds(1f);
        if (playerController.ArrowCount <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        if (!gameIsOver)
        {
            gameIsOver = true;
            OnGameOver?.Invoke();
        }
    }
}







