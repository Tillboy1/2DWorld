using UnityEngine;

public enum BounusType
{
    DammageIncrease,
    HealthIncrease,
    AttackspeedIncrease,
    DebuffReduction,
}
[CreateAssetMenu(fileName = "ShellLinework", menuName = "Scriptable Objects/Shell/ShellLinework")]
public class ShellLinework : ShellShard
{
    public Sprite LineSprite;

    public BounusType LineBounus;
}
