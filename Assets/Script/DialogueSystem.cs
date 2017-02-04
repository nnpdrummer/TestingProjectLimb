using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public TextAsset textFile;
    private string[] textLines;
    private List<DialogueNode> dialogueNodes;

    public Text dialogueTextBox;
    public Image characterPic;
    public Text playerChoice1;
    public Text playerChoice2;
    public Text playerChoice3;
    public Text playerChoice4;
    public Text playerChoice5;

    private void Start()
    {
        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
            ParseInformation();
            DisplayInformation();
        }
    }

    private void DisplayInformation()
    {
        dialogueTextBox.text = dialogueNodes[0].getPrompt();
    }

    private void ParseInformation()
    {
        int nodeID = 0, linkedNode = -1;
        string characterName = "", prompt = "";
        List<DialogueChoice> playerChoices = new List<DialogueChoice>();
        dialogueNodes = new List<DialogueNode>();
        prompt = "";

        for (int lineIterator = 0; lineIterator < textLines.Length; lineIterator++)
        {
            string currentLine = textLines[lineIterator].Trim();

            if (char.IsNumber(currentLine[0]))
            {
                int.TryParse(currentLine, out nodeID);
            }
            else if (isCharacterName(currentLine))
            {
                characterName = currentLine;
            }
            else if (currentLine[0] == '*')
            {
                linkedNode = (int)char.GetNumericValue(currentLine[currentLine.Length - 1]);
                currentLine = currentLine.TrimEnd();
                currentLine.Trim('*');
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
            else
            {
                prompt += currentLine;
            }
        }
    }

    private bool isCharacterName(string nameToCheck)
    {
        switch(nameToCheck)
        {
            case "Coleridge1": case "Coleridge2": return true;
            default: return false;
        }
    }
}
