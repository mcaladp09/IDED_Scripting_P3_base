using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int arrowCount = 0;

    private Ray ray;
    private RaycastHit hit;

    private Vector3 mousePosition;
    private Camera mainCamera;

    public GameController gameController;

    public int ArrowCount { get => arrowCount; private set => arrowCount = value; }

    private void Start()
    {
        ArrowCount = gameController.Arrows;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (ArrowCount > 0 && Input.GetMouseButtonUp(0))
        {
            ArrowCount--;

            mousePosition = Input.mousePosition;
            ray = mainCamera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                gameController.SetMark(hit.point);
                print("Hit someting");
            }
        }
    }
}