using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class ExtentionMethods 
{
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static Vector3 ToVector3(this Direction dir)
    {
        switch (dir)
        {
            case Direction.LEFT:
                return Vector3.left;
            case Direction.RIGHT:
                return Vector3.right;
            case Direction.UP:
                return Vector3.up;
            case Direction.DOWN:
                return Vector3.down;
        }
        return Vector3.down;
    }
}
