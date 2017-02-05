using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextAsset textFile;
    public GameObject dialoguePrefab;

    private GameObject dialogueWindow;
    private GameObject characterDialogueText;
    private GameObject playerChoice1;
    private GameObject playerChoice2;
    private GameObject playerChoice3;
    private GameObject playerChoice4;
    private GameObject playerChoice5;

    private int selectedOption;
    private List<DialogueNode> nodes;
    private string currentPrompt;

    private void Start()
    {
        BuildNodeTree();
        FindObjectsInScene();
        StartCoroutine("DisplayNodes");
    }

    private void BuildNodeTree()
    {
        DialogueSystem dS = new DialogueSystem(textFile);
        nodes = dS.getNodeTree();
    }

    private void FindObjectsInScene()
    {
        GameObject canvas = GameObject.Find("MainCanvas");

        dialogueWindow = Instantiate<GameObject>(dialoguePrefab);
        dialogueWindow.transform.parent = canvas.transform;
        RectTransform dialogueWindowTransform = (RectTransform)dialogueWindow.transform;
        dialogueWindowTransform.localPosition = new Vector2(0, -200);

        characterDialogueText = GameObject.Find("CharacterDialogueText");
        playerChoice1 = GameObject.Find("PlayerChoice1Text");
        playerChoice2 = GameObject.Find("PlayerChoice2Text");
        playerChoice3 = GameObject.Find("PlayerChoice3Text");
        playerChoice4 = GameObject.Find("PlayerChoice4Text");
        playerChoice5 = GameObject.Find("PlayerChoice5Text");
    }

    private void SetSelectedOption(int x)
    {
        selectedOption = x;
    }

    public IEnumerator DisplayNodes()
    {
        int nodeID = 0;
        selectedOption = -2;

        while (nodeID != -1)
        {
            Display(nodes[nodeID]);

            selectedOption = -2;
            while(selectedOption == -2)
            {
                yield return new WaitForSeconds(.01f);
            }
            nodeID = selectedOption;
        }
        dialogueWindow.SetActive(false);
    }

    private void Display(DialogueNode node)
    {
        StartCoroutine(ScrollText(node.getPrompt()));

        playerChoice1.SetActive(false);
        playerChoice2.SetActive(false);
        playerChoice3.SetActive(false);
        playerChoice4.SetActive(false);
        playerChoice5.SetActive(false);

        StartCoroutine(ButtonsPopUp(node));
    }

    public IEnumerator ScrollText(string prompt)
    {
        characterDialogueText.GetComponent<Text>().text = "";
        foreach(char c in prompt)
        {
            characterDialogueText.GetComponent<Text>().text += c;
            yield return new WaitForSeconds(.015f);
        }
    }

    public IEnumerator ButtonsPopUp(DialogueNode node)
    {
        yield return new WaitForSeconds(1.2f);
        
        for (int oI = 0; oI < node.getManyChoices(); oI++)
        {
            switch (oI)
            {
                case 0:
                    setChoiceButton(playerChoice1, node.getChoiceNumber(oI)); break;
                case 1:
                    setChoiceButton(playerChoice2, node.getChoiceNumber(oI)); break;
                case 2:
                    setChoiceButton(playerChoice3, node.getChoiceNumber(oI)); break;
                case 3:
                    setChoiceButton(playerChoice4, node.getChoiceNumber(oI)); break;
                case 4:
                    setChoiceButton(playerChoice5, node.getChoiceNumber(oI)); break;
            }
        }

    }

    private void setChoiceButton(GameObject button, DialogueChoice choice)
    {
        button.SetActive(true);
        button.GetComponent<Text>().text = choice.getChoiceText();
        button.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(choice.getLinkedNode()); });
    }
}
