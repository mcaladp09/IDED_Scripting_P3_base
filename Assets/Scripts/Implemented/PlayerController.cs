using UnityEngine;

public class PlayerController : PlayerControllerBase
{
    [SerializeField]
    private GameController gameController;

    protected override void Start()
    {
        ArrowCount = gameController.Arrows;
        base.Start();
    }

    protected override void ProcessShot(Vector3 point)
    {
        gameController?.ProcessShot(point);
    }
}