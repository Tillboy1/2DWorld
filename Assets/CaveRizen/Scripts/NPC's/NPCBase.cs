using System.Collections.Generic;
using UnityEngine;

public class NPCBase : InteractableBase
{
    public float talkingLocation;
    public bool lookLeftWhileTalking;
    public List<ConvosationDialogue> Convasations;
    public override void Interact()
    {
        PlayerToLocation();
        talk();
    }

    private void talk()
    {
        Debug.Log("Talking ");
        // Talking Start
        if (Convasations[0].convosationAllowed && !Convasations[0].RepeatedConvisation)
        {
            // Introduction to character
            PlayerManager.instance.Displaynextparagraph(Convasations[0]);
        }
        else
        {
            for (int i = 0; i < Convasations.Count; i++)
            {
                PlayerManager.instance.Displaynextparagraph(Convasations[i]);
            }
        }
    }
    public void PlayerToLocation()
    {
        // Looks towards the npc
        // Goes To talkingLocation
    }

    public override void LeavingArea(GameObject PlayerLeaving)
    {
        //Debug.Log("Leaving area");
    }
}
