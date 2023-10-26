using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private int arrows = 10;

    [SerializeField]
    private GameObject markGO;

    private float[] ringDistances;

    private Vector3 ringCenter;

    public int Score { get; private set; }
    public int Arrows { get => arrows; }

    public int RemainingArrows { get => playerController.ArrowCount; }

    public void CalculateScore(Vector3 shotPosition)
    {
        SetMark(shotPosition);

        float distanceToCenter = (shotPosition - ringCenter).magnitude;
        print($"Distance to bullseye: {distanceToCenter:0.00}");

        int scoreAdd = 10;

        for (int i = 0; i < ringDistances.Length; i++)
        {
            if (distanceToCenter > ringDistances[i])
            {
                scoreAdd -= 1;
            }
        }

        Score += scoreAdd;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    private void Awake()
    {
        if (playerController != null)
        {
            playerController.gameController = this;
        }

        InitializeRing();
    }

    private void SetMark(Vector3 shotPosition)
    {
        markGO.transform.position = shotPosition;
    }

    private void InitializeRing()
    {
        GameObject[] ringRefs = GameObject.FindGameObjectsWithTag("RingReference");

        if (ringRefs.Length > 0)
        {
            ringDistances = new float[ringRefs.Length];

            ringCenter = GameObject.FindGameObjectWithTag("Target").transform.position;

            for (int i = 0; i < ringDistances.Length; i++)
            {
                ringDistances[i] = (ringRefs[i].transform.position - ringCenter).magnitude;
            }

            ringDistances.SortAscendent();
        }
    }
}