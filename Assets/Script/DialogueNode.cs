using System.Collections;
using System.Collections.Generic;

public class DialogueNode
{
    private int nodeID;
    private string characterName;
    private string prompt;
    private string[] responses;

    public DialogueNode()
    {
        nodeID = -2;
        characterName = "";
        prompt = "";
        responses = new string[0];
    }

    public DialogueNode(int newNodeID, string newName, string newPrompt, string[] newResponses)
    {
        nodeID = newNodeID;
        characterName = newName;
        prompt = newPrompt;
        copyArray(newResponses);
    }

    private void copyArray(string[] newResponses)
    {
        responses = new string[newResponses.Length];

        for(int responseIterator = 0; responseIterator < newResponses.Length; responseIterator++)
        {
            responses[responseIterator] = newResponses[responseIterator];
        }
    }
}
