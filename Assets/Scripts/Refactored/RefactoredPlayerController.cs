using UnityEngine;

public class RefactoredPlayerController : PlayerControllerBase
{
    public static RefactoredPlayerController Instance { get; private set; }

    public int Arrows = 10;

    public event System.Action<Vector3> OnShotFired;

    protected override void Start()
    {
        base.Start();
        ArrowCount = Arrows;  // Asigna el valor inicial del conteo de flechas
    }

    public void ProcessShot(Vector3 point)
    {
        // Implementa la l�gica de procesamiento del disparo aqu�
        ArrowCount--;
        RefactoredGameController.Instance.ProcessShot(point); // Llama al m�todo ProcessShot con la posici�n del disparo
    }

    private void Awake()
    {
        Instance = this; // Asigna la instancia actual a la propiedad
    }
}
