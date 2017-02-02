using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : PanelButton
{
    // The buttons that appear when the web button is clicked (or hovered over).
    public GameObject itemsButton;
    public GameObject keyItemsButton;
    public GameObject crapButton;

    // Used to make the "pulse" effect on the above buttons.
    private float itemsButtonSizeX;
    private float itemsButtonSizeY;
    private float keyItemsButtonSizeX;
    private float keyItemsButtonSizeY;
    private float crapButtonSizeX;
    private float crapButtonSizeY;

    public override void OnClickEvent()
    {
        // Opens or closes the web panel depending if it is closed or open.
        if (inventoryPanel.activeSelf) { inventoryPanel.SetActive(false); }
        else { inventoryPanel.SetActive(true); PanelButtonPulse(); }

        // Closes all of the non web panels.
        CloseNonInventoryPanels();
    }

    // Obtains the dimensions of the investigation panel's buttons.
    protected override void GetButtonDimensions()
    {
        itemsButtonSizeX = itemsButton.transform.localScale.x;
        itemsButtonSizeY = itemsButton.transform.localScale.y;
        keyItemsButtonSizeX = keyItemsButton.transform.localScale.x;
        keyItemsButtonSizeY = keyItemsButton.transform.localScale.y;
        crapButtonSizeX = crapButton.transform.localScale.x;
        crapButtonSizeY = crapButton.transform.localScale.y;
    }

    // Scales up the following buttons. Used for first half of pulse.
    protected override void scaleUpPanelButtons()
    {
        itemsButton.transform.localScale = new Vector2(itemsButtonSizeX + getButtonScaleIncrease(), itemsButtonSizeY + getButtonScaleIncrease());
        keyItemsButton.transform.localScale = new Vector2(keyItemsButtonSizeX + getButtonScaleIncrease(), keyItemsButtonSizeY + getButtonScaleIncrease());
        crapButton.transform.localScale = new Vector2(crapButtonSizeX + getButtonScaleIncrease(), crapButtonSizeY + getButtonScaleIncrease());
    }

    // Scales down the following buttons. Used for second half of pulse.
    protected override void scaleDownPanelButtons()
    {
        itemsButton.transform.localScale = new Vector2(itemsButtonSizeX, itemsButtonSizeY);
        keyItemsButton.transform.localScale = new Vector2(keyItemsButtonSizeX, keyItemsButtonSizeY);
        crapButton.transform.localScale = new Vector2(crapButtonSizeX, crapButtonSizeY);
    }

    // Closes all panels that are not the web panel. Used to avoid overlapping.
    private void CloseNonInventoryPanels()
    {
        investigationPanel.SetActive(false);
        brycePanel.SetActive(false);
        mediaPanel.SetActive(false);
        webPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
}
