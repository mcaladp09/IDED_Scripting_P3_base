using UnityEngine;

public class GameController : GameControllerBase
{
    [SerializeField]
    private PlayerController playerController;

    public override PlayerControllerBase PlayerController => playerController;
}