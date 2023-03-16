using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GemManager
{
    public static List<LevelGems> Levels = new List<LevelGems>();
    public static void ResetLevels()
    {
        Levels.Clear();
        for (int levelIndex = 0; levelIndex < Levels.Count; levelIndex++)
        {
            LevelGems newLevel = new LevelGems();
            newLevel.Level = levelIndex;
            newLevel.Gems = new bool[] {false, false, false};
        }
    }
}

public struct LevelGems
{
    public int Level;
    public bool[] gems;
    public bool[] Gems { get => gems; set => gems = value; }
}