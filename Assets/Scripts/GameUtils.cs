using UnityEngine;

public static class GameUtils
{
    public static Vector3 GetRandomUnitVector() =>
        new Vector3(
            Random.Range(-1F, 1.0F),
            Random.Range(-1F, 1.0F),
            0F);

    public static float GetRandomFloat() => Random.Range(0F, GameController.MAX_WIND_SPEED);

    public static float DistanceTo(this Vector3 a, Vector3 b) => (a - b).magnitude;

    public static void SortAscendent(this float[] arr)
    {
        int arrLength = arr.Length;
        float temp = 0F;

        for (int i = 0; i < arrLength - 1; i++)
        {
            for (int j = 0; j < arrLength - i - 1; j++)
            {
                int nextIndex = j + 1;

                if (arr[j] > arr[nextIndex])
                {
                    temp = arr[j];
                    arr[j] = arr[nextIndex];
                    arr[nextIndex] = temp;
                }
            }
        }
    }

    public static float GetAngleFromVector(Vector3 direction)
    {
        float angle = Vector3.Angle(new Vector3(0.0f, 1.0f, 0.0f), direction);

        if (angle < 0F)
        {
            angle = -angle + 360F;
        }

        return angle;
    }
}