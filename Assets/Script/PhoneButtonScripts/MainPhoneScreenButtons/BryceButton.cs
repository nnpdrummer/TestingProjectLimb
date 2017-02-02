using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BryceButton : PanelButton
{
    // The buttons that appear when the Bryce button is clicked (or hovered over).
    public GameObject statusButton;
    public GameObject equipmentButton;
    public GameObject partnerButton;

    // Used to make the "pulse" effect on the above buttons.
    private float statusButtonSizeX;
    private float statusButtonSizeY;
    private float equipmentButtonSizeX;
    private float equipmentButtonSizeY;
    private float partnerButtonSizeX;
    private float partnerButtonSizeY;

    public override void OnClickEvent()
    {
        // Opens or closes the web panel depending if it is closed or open.
        if (brycePanel.activeSelf) { brycePanel.SetActive(false); }
        else { brycePanel.SetActive(true); PanelButtonPulse(); }

        // Closes all of the non Bryce panels.
        CloseNonBrycePanels();
    }

    // Obtains the dimensions of the Bryce panel's buttons.
    protected override void GetButtonDimensions()
    {
        statusButtonSizeX = statusButton.transform.localScale.x;
        statusButtonSizeY = statusButton.transform.localScale.y;
        equipmentButtonSizeX = equipmentButton.transform.localScale.x;
        equipmentButtonSizeY = equipmentButton.transform.localScale.y;
        partnerButtonSizeX = partnerButton.transform.localScale.x;
        partnerButtonSizeY = partnerButton.transform.localScale.y;
    }

    // Scales up the following buttons. Used for first half of pulse.
    protected override void scaleUpPanelButtons()
    {
        statusButton.transform.localScale = new Vector2(statusButtonSizeX + getButtonScaleIncrease(), statusButtonSizeY + getButtonScaleIncrease());
        equipmentButton.transform.localScale = new Vector2(equipmentButtonSizeX + getButtonScaleIncrease(), equipmentButtonSizeY + getButtonScaleIncrease());
        partnerButton.transform.localScale = new Vector2(partnerButtonSizeX + getButtonScaleIncrease(), partnerButtonSizeY + getButtonScaleIncrease());
    }

    // Scales down the following buttons. Used for second half of pulse.
    protected override void scaleDownPanelButtons()
    {
        statusButton.transform.localScale = new Vector2(statusButtonSizeX, statusButtonSizeY);
        equipmentButton.transform.localScale = new Vector2(equipmentButtonSizeX, equipmentButtonSizeY);
        partnerButton.transform.localScale = new Vector2(partnerButtonSizeX, partnerButtonSizeY);
    }

    // Closes all panels that are not the web panel. Used to avoid overlapping.
    private void CloseNonBrycePanels()
    {
        investigationPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        mediaPanel.SetActive(false);
        webPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
}
