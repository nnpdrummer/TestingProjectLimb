using System.Collections;
using System.Collections.Generic;

public class DialogueNode
{
    //Holds the contents of each dialogue node.
    private int nodeID;
    private string characterName;
    private string prompt;
    private List<DialogueChoice> responses;
    //Add conditions ^

    //Empty constructor, just in case.
    public DialogueNode()
    {
        nodeID = -1;
        characterName = "";
        prompt = "";
        responses = new List<DialogueChoice>();
    }

    //Properly initializes all of the data above.
    public DialogueNode(int newNodeID, string newName, string newPrompt, List<DialogueChoice> newResponses)
    {
        nodeID = newNodeID;
        characterName = newName;
        prompt = newPrompt;
        responses = new List<DialogueChoice>(newResponses);
    }

    //Returns the node ID
    public int getNodeID()
    {
        return nodeID;
    }

    //Returns the prompt
    public string getPrompt()
    {
        return prompt;
    }

    //Returns the text of a particular player choice.
    public DialogueChoice getChoiceNumber(int choiceNumber)
    {
        return responses[choiceNumber];
    }

    //Returns the amount of player choices in a node.
    public int getManyChoices()
    {
        return responses.Count;
    }
}
