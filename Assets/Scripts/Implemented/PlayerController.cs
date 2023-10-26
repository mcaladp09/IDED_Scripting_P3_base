public class PlayerController : PlayerControllerBase
{
    public GameController gameController;

    protected override void Start()
    {
        ArrowCount = gameController.Arrows;
        base.Start();
    }

    protected override GameController GameController => gameController;
}