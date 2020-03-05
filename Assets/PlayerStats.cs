using UnityEngine;
using UnityEditor;
public static class PlayerStats
{
    private static Vector3 position;

 

    public static Vector3 Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
        }
    }

    public static bool HaveClue { get; internal set; }
    public static bool isAlreadySent { get; internal set; }
}