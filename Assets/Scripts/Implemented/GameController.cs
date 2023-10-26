using UnityEngine;

public class GameController : GameControllerBase
{
    [SerializeField]
    private PlayerController playerController;

    public override PlayerControllerBase PlayerController => playerController;

    protected override void Awake()
    {
        base.Awake();

        if (playerController != null)
        {
            playerController.gameController = this;
        }
    }
}