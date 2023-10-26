using UnityEngine;

public abstract class PlayerControllerBase : MonoBehaviour
{
    private int arrowCount = 0;

    private Ray ray;
    private RaycastHit hit;

    private Vector3 mousePosition;
    private Camera mainCamera;

    public int ArrowCount { get => arrowCount; protected set => arrowCount = value; }

    protected virtual void Start()
    {
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
                ProcessShot(hit.point);
                print("Hit someting");
            }
        }
    }

    protected abstract void ProcessShot(Vector3 point);
}