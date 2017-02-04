using System.Collections;
using System.Collections.Generic;

public class DialogueChoice
{
    private string choiceText;
    private int linkedNodeID;

    //public DialogueChoice() { }
    public DialogueChoice(string newChoiceText, int newLinkedNodeID)
    {
        choiceText = newChoiceText;
        linkedNodeID = newLinkedNodeID;
    }
}
