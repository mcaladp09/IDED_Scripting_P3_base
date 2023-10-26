using UnityEngine;

public abstract class PlayerControllerBase : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    private Vector3 mousePosition;
    private Camera mainCamera;

    public int ArrowCount { get; protected set; }

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