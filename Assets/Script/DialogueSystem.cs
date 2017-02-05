using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueSystem 
{
    private string[] textLines;
    private List<DialogueNode> dialogueNodes;
    private string prompt;
    private string characterName;
    private int nodeID;
    private int linkedNode;

    //Ensures the Text file is truely there and parses its contents if it is.
    public DialogueSystem(TextAsset textFile)
    {
        dialogueNodes = new List<DialogueNode>();
        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
            ParseInformation();
        }
    }

    //Returns the nodes so they can be implemented in another class.
    public List<DialogueNode> getNodeTree()
    {
        return dialogueNodes;
    }

    // Takes the information from the text file and puts it into separte nodes. Separate nodes are denoted by '~'.
    private void ParseInformation()
    {
        InitializeVariables();
        List<DialogueChoice> playerChoices = new List<DialogueChoice>();

        for (int lI = 0; lI < textLines.Length; lI++)
        {
            string currentLine = textLines[lI].Trim();
            int lineLength = currentLine.Length;

            if (char.IsNumber(currentLine[0])) int.TryParse(currentLine, out nodeID);
            else if (IsCharacterName(currentLine)) characterName = currentLine; 

            else if (currentLine[0] == '*')
            {
                if (currentLine[lineLength - 2] == '-') { linkedNode = -1; }
                else { linkedNode = (int)char.GetNumericValue(currentLine[lineLength - 1]); }

                currentLine = currentLine.Remove(lineLength - 2);
                DialogueChoice newChoice = new DialogueChoice(currentLine, linkedNode);
                playerChoices.Add(newChoice);
            }
            else if (currentLine.Equals("~"))
            {
                DialogueNode newNode = new DialogueNode(nodeID, characterName, prompt, playerChoices);
                dialogueNodes.Add(newNode);
                playerChoices.Clear();
                prompt = "";
            }
            else prompt += currentLine;
        }
    }

    //Simple function used to initialize global variables.
    private void InitializeVariables()
    {
        nodeID = 0;
        linkedNode = 0;
        characterName = "";
        prompt = "";
    }

    //Checks against a plethora of character names and moods to see if a line is used to define the character speaking or not.
    private bool IsCharacterName(string nameToCheck)
    {
        switch (nameToCheck)
        {
            case "Coleridge1": case "Coleridge2": return true;//Will add to these once more characters are introduced.
            default: return false;
        }
    }
}
