using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : PanelButton
{
    // The buttons that appear when the web button is clicked (or hovered over).
    public GameObject saveButton;
    public GameObject loadButton;
    public GameObject quitButton;

    // Used to make the "pulse" effect on the above buttons.
    private float saveButtonSizeX;
    private float saveButtonSizeY;
    private float loadButtonSizeX;
    private float loadButtonSizeY;
    private float quitButtonSizeX;
    private float quitButtonSizeY;

    public override void OnClickEvent()
    {
        // Opens or closes the web panel depending if it is closed or open.
        if (optionsPanel.activeSelf) { optionsPanel.SetActive(false); }
        else { optionsPanel.SetActive(true); PanelButtonPulse(); }

        // Closes all of the non options panels.
        CloseNonOptionsPanels();
    }

    // Obtains the dimensions of the options panel's buttons.
    protected override void GetButtonDimensions()
    {
        saveButtonSizeX = saveButton.transform.localScale.x;
        saveButtonSizeY = saveButton.transform.localScale.y;
        loadButtonSizeX = loadButton.transform.localScale.x;
        loadButtonSizeY = loadButton.transform.localScale.y;
        quitButtonSizeX = quitButton.transform.localScale.x;
        quitButtonSizeY = quitButton.transform.localScale.y;
    }

    // Scales up the following buttons. Used for first half of pulse.
    protected override void scaleUpPanelButtons()
    {
        saveButton.transform.localScale = new Vector2(saveButtonSizeX + getButtonScaleIncrease(), saveButtonSizeY + getButtonScaleIncrease());
        loadButton.transform.localScale = new Vector2(loadButtonSizeX + getButtonScaleIncrease(), loadButtonSizeY + getButtonScaleIncrease());
        quitButton.transform.localScale = new Vector2(quitButtonSizeX + getButtonScaleIncrease(), quitButtonSizeY + getButtonScaleIncrease());
    }

    // Scales down the following buttons. Used for second half of pulse.
    protected override void scaleDownPanelButtons()
    {
        saveButton.transform.localScale = new Vector2(saveButtonSizeX, saveButtonSizeY);
        loadButton.transform.localScale = new Vector2(loadButtonSizeX, loadButtonSizeY);
        quitButton.transform.localScale = new Vector2(quitButtonSizeX, quitButtonSizeY);
    }

    // Closes all panels that are not the web panel. Used to avoid overlapping.
    private void CloseNonOptionsPanels()
    {
        investigationPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        brycePanel.SetActive(false);
        mediaPanel.SetActive(false);
        webPanel.SetActive(false);
    }
}
