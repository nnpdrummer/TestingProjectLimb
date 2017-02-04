using System.Collections;
using System.Collections.Generic;

public class DialogueNode
{
    private int nodeID;
    private string characterName;
    private string prompt;
    private List<DialogueChoice> responses;

    public DialogueNode()
    {
        nodeID = -1;
        characterName = "";
        prompt = "";
        responses = new List<DialogueChoice>();
    }

    public DialogueNode(int newNodeID, string newName, string newPrompt, List<DialogueChoice> newResponses)
    {
        nodeID = newNodeID;
        characterName = newName;
        prompt = newPrompt;
        responses = new List<DialogueChoice>(newResponses);
    }

    public int getNodeID()
    {
        return nodeID;
    }

    public string getPrompt()
    {
        return prompt;
    }
}
