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

    public int Score { get; private set; }
    public int Arrows { get => arrows; }

    public int RemainingArrows { get => playerController.ArrowCount; }

    public void CalculateScore(Vector3 shotPosition)
    {
    }

    public void SetMark(Vector3 markPos)
    {
        markGO.transform.position = markPos;
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

    private void InitializeRing()
    {
        GameObject[] ringRefs = GameObject.FindGameObjectsWithTag("RingReference");

        if (ringRefs.Length > 0)
        {
            ringDistances = new float[ringRefs.Length];

            Vector3 ringCenter = GameObject.FindGameObjectWithTag("Target").transform.position;

            for (int i = 0; i < ringDistances.Length; i++)
            {
                ringDistances[i] = (ringRefs[i].transform.position - ringCenter).magnitude;
            }

            ringDistances.SortAscendent();
        }
    }

    
}