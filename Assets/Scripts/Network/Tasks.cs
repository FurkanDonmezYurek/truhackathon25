using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks
{
    public string Count { get; set; }
    public string Level { get; set; }
    public string AppleCount { get; set; }
    public string BadAppleCount { get; set; }
    public string Timer { get; set; }
    public string Score { get; set; }

    public Tasks(
        string count,
        string level,
        string timer,
        string appleCount,
        string badAppleCount,
        string score
    )
    {
        Count = count;
        Level = level;
        Timer = timer;
        AppleCount = appleCount;
        BadAppleCount = badAppleCount;
        Score = score;
    }

    public override string ToString()
    {
        return $"Task Count: {Count}, Level: {Level}, Timer: {Timer}, AppleCount:{AppleCount}, BadAppleCount:{BadAppleCount}";
    }
}
