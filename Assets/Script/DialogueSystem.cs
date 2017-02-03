using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueSystem : MonoBehaviour {

    public TextAsset textFile;
    private string[] textLines;
    private char[] p;
    public int nodeCounter;
    public string element1;

    private void Start()
    {
        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
        }
        CopyLines();
        CreateNodes();
    }

    private void CopyLines()
    {
        p = new char[textLines[0].Length];
        for (int pI = 0; pI < textLines[0].Length; pI++)
        {
            p[pI] = textLines[0][pI];
            Debug.Log(p[pI]);
        }

        Debug.Log(p[1] == '\n');
    }

    private void CreateNodes()
    {
        nodeCounter = 0;

        //element1 = p[2];

        // Debug.Log(p[2]);
        //Debug.Log("updated" + p[2].Equals("Ugghhhh, today is such a long day; can't wait to go home and smell my dog."));

        //for (int lineIterator = 0; lineIterator < textLines.Length; lineIterator++)
        //{
        //    if (textLines[lineIterator].Equals("0 "))
        //    {
        //        Debug.Log("Did we get here?");
        //        nodeCounter++;
        //    }
        //}
    }
}
