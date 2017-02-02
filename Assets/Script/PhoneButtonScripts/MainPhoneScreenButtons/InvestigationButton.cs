using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationButton : PanelButton
{
    // The buttons that appear when the investigation button is clicked (or hovered over).
    public GameObject peopleButton;
    public GameObject eventsButton;
    public GameObject caseLogButton;

    // Used to make the "pulse" effect on the above buttons.
    private float peopleButtonSizeX;
    private float peopleButtonSizeY;
    private float eventsButtonSizeX;
    private float eventsButtonSizeY;
    private float caseLogButtonSizeX;
    private float caseLogButtonSizeY;

	public override void OnClickEvent()
    {
        // Opens or closes the web panel depending if it is closed or open.
        if (investigationPanel.activeSelf) { investigationPanel.SetActive(false);  }
        else { investigationPanel.SetActive(true); PanelButtonPulse(); }

        // Closes all of the non investigation panels.
        CloseNonInvestigationPanels();
    }

    // Obtains the dimensions of the web panel's buttons.
    protected override void GetButtonDimensions()
    {
        peopleButtonSizeX = peopleButton.transform.localScale.x;
        peopleButtonSizeY = peopleButton.transform.localScale.y;
        eventsButtonSizeX = eventsButton.transform.localScale.x;
        eventsButtonSizeY = eventsButton.transform.localScale.y;
        caseLogButtonSizeX = caseLogButton.transform.localScale.x;
        caseLogButtonSizeY = caseLogButton.transform.localScale.y;
    }

    // Scales up the following buttons. Used for first half of pulse.
    protected override void scaleUpPanelButtons()
    {
        peopleButton.transform.localScale = new Vector2(peopleButtonSizeX + getButtonScaleIncrease(), peopleButtonSizeY + getButtonScaleIncrease());
        eventsButton.transform.localScale = new Vector2(eventsButtonSizeX + getButtonScaleIncrease(), eventsButtonSizeY + getButtonScaleIncrease());
        caseLogButton.transform.localScale = new Vector2(caseLogButtonSizeX + getButtonScaleIncrease(), caseLogButtonSizeY + getButtonScaleIncrease());
    }

    // Scales down the following buttons. Used for second half of pulse.
    protected override void scaleDownPanelButtons()
    {
        peopleButton.transform.localScale = new Vector2(peopleButtonSizeX, peopleButtonSizeY);
        eventsButton.transform.localScale = new Vector2(eventsButtonSizeX, eventsButtonSizeY);
        caseLogButton.transform.localScale = new Vector2(caseLogButtonSizeX, caseLogButtonSizeY);
    }

    // Closes all panels that are not the investigation panel. Used to avoid overlapping.
    private void CloseNonInvestigationPanels()
    {
        inventoryPanel.SetActive(false);
        brycePanel.SetActive(false);
        mediaPanel.SetActive(false);
        webPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
}
