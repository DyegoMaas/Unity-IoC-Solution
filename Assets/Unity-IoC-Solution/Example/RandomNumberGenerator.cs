using UnityEngine;

public class RandomNumberGenerator : INumberGenerator
{
    private int min;

    public int Min
    {
        get { return min; }
        set
        {
            if (value > max)
                return;

            min = value;
        }
    }

    private int max;

    public int Max
    {
        get { return max; }
        set
        {
            if (value < min)
                return;

            max = value;
        }
    }
    
    public RandomNumberGenerator()
    {
        Min = 5;
        Max = 10;
    }

    public int GenerateNumberOfCubes()
    {
        return Random.Range(min, max);
    }
}