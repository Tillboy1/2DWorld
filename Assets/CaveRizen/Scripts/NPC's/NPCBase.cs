using System.Collections.Generic;
using UnityEngine;

public class NPCBase : InteractableBase
{
    public float talkingLocation;
    public bool lookLeftWhileTalking;
    public List<ConvosationDialogue> Convasations;
    public override void Interact()
    {
        GoToLocation();
        // Talking Start
    }
    public void GoToLocation()
    {
        // Looks towards the npc
        // Goes To talkingLocation
    }
}
