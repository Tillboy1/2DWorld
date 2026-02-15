using Unity.VisualScripting;
using UnityEngine;

public enum ShellArea
{
    Enjuelment,
    Modifire,
    Linework
}
[CreateAssetMenu(fileName = "ShellScripts", menuName = "Scriptable Objects/ShellScripts")]
public class ShellScripts : ScriptableObject
{
    public string Description;
    public ShellArea Convosation;
}

public class shell
{
    public string Description;
    public ShellArea Resources;

    public shell(ShellScripts Shell)
    {
        Description = Shell.Description;
        Resources = Shell.Convosation;
    }
}
