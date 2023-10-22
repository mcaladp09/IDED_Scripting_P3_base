using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int arrows = 3;

    private int arrowCount = 0;

    private Ray ray;
    private RaycastHit hit;

    private Vector3 mousePosition;
    private Camera mainCamera;

    public GameController gameController;

    private void Start()
    {
        arrowCount = arrows;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (arrowCount > 0 && Input.GetMouseButtonUp(0))
        {
            arrowCount--;

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