using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class GameControllerBase : MonoBehaviour
{
    public const float MAX_WIND_SPEED = 1.25F;

    [SerializeField]
    private int arrows = 10;

    [SerializeField]
    private GameObject markGO;

    private float windSpeed = 0.0F;

    private float[] ringDistances;

    private Vector3 ringCenter;
    private Vector3 windDirection;
    private Vector3 shotPosition;

    public int Score { get; protected set; }
    public int Arrows { get => arrows; }

    public abstract PlayerControllerBase PlayerController { get; }

    public int RemainingArrows => PlayerController.ArrowCount;
    public float WindSpeed { get => windSpeed; private set => windSpeed = value; }

    public void ProcessShot(Vector3 aimPosition)
    {
        shotPosition = aimPosition + (windDirection * WindSpeed);
        SetMark(shotPosition);
        CalculateScore(shotPosition);

        SetWindStats();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    protected virtual void Awake()
    {
        InitializeRing();
        SetWindStats();
    }

    private void CalculateScore(Vector3 shotPosition)
    {
        float distanceToCenter = (shotPosition - ringCenter).magnitude;
        print(string.Format("Distance to bullseye: {0:0.00F}", distanceToCenter));

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

    private void SetMark(Vector3 shotPosition)
    {
        markGO.transform.position = shotPosition;
    }

    private void SetWindStats()
    {
        windDirection = GameUtils.GetRandomUnitVector();
        WindSpeed = GameUtils.GetRandomFloat();
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