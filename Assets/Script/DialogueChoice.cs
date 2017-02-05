using System.Collections;
using System.Collections.Generic;

public class DialogueChoice
{
    private string choiceText;
    private int linkedNodeID; //Important, used to link to other nodes.
   
    //Initializes the above global variables.
    public DialogueChoice(string newChoiceText, int newLinkedNodeID)
    {
        choiceText = newChoiceText;
        linkedNodeID = newLinkedNodeID;
    }

    //Returns the text of the choice.
    public string getChoiceText()
    {
        return choiceText;
    }

    //Returns the link that this choice is linked to.
    public int getLinkedNode()
    {
        return linkedNodeID;
    }
}
