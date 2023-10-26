public static class GameUtils
{
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
}