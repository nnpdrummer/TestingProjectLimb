using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceButton : PhoneButton
{
    public GameObject investigationPanel;
    public GameObject inventoryPanel;
    public GameObject brycePanel;
    public GameObject mediaPanel;
    public GameObject webPanel;
    public GameObject optionsPanel;
    public GameObject mainPhoneScreenPanel;
    public GameObject mapPhoneScreenPanel;

    // To be changed by children
    public override void OnClickEvent() { Debug.Log("Face Button pressed"); }

    // Possibly add a function to return to main canvas with implementation of other buttons

    // Closes all of the associated panels associated with each main phone button.
    protected void CloseAllPanels()
    {
        investigationPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        brycePanel.SetActive(false);
        mediaPanel.SetActive(false);
        webPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
}
