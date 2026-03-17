using UnityEngine;

[CreateAssetMenu(fileName = "ConvosationDialogue", menuName = "Scriptable Objects/ConvosationDialogue")]
public class ConvosationDialogue : ScriptableObject
{
    public int Id;
    public bool RepeatedConvisation;
    public bool convosationAllowed;
    public ConvosationPiece[] Convosation;
}

public class Recipe
{
    public int Id;
    public bool RepeatedConvo;
    public bool convoAllowed;
    public ConvosationPiece[] Resources;

    public Recipe(ConvosationDialogue convo)
    {
        Id = convo.Id;
        
        Resources = convo.Convosation;
        RepeatedConvo = convo.RepeatedConvisation;
        convoAllowed = convo.convosationAllowed;
        Resources = new ConvosationPiece[convo.Convosation.Length];
    }
}

[System.Serializable]
public class ConvosationPiece
{
    public string SpeakerName;
    [TextArea(5,10)]
    public string[] Description;
}
