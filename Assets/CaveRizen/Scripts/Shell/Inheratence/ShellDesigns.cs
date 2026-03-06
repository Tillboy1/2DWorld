using UnityEngine;

[CreateAssetMenu(fileName = "ShellDesigns", menuName = "Scriptable Objects/Shell/ShellDesigns")]
public class ShellDesigns : ScriptableObject
{
    public ShellCore Core;
    public ShellLinework Linework;

    public UtilityShard[] Utility;
    public CombatShard[] Combat;
}
