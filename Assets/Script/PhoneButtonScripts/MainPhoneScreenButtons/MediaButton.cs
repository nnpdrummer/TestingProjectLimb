using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaButton : PanelButton
{
    // The buttons that appear when the media button is clicked (or hovered over).
    public GameObject aAMButton;
    public GameObject chirpButton;
    public GameObject newsButton;

    // Used to make the "pulse" effect on the above buttons.
    private float aAMButtonSizeX;
    private float aAMButtonSizeY;
    private float chirpButtonSizeX;
    private float chirpButtonSizeY;
    private float newsButtonSizeX;
    private float newsButtonSizeY;
    
    public override void OnClickEvent()
    {
        // Opens or closes the web panel depending if it is closed or open.
        if (mediaPanel.activeSelf) { mediaPanel.SetActive(false); }
        else { mediaPanel.SetActive(true); PanelButtonPulse(); }

        // Closes all of the non web panels.
        CloseNonMediaPanels();
    }

    // Obtains the dimensions of the media panel's buttons.
    protected override void GetButtonDimensions()
    {
        aAMButtonSizeX = aAMButton.transform.localScale.x;
        aAMButtonSizeY = aAMButton.transform.localScale.y;
        chirpButtonSizeX = chirpButton.transform.localScale.x;
        chirpButtonSizeY = chirpButton.transform.localScale.y;
        newsButtonSizeX = newsButton.transform.localScale.x;
        newsButtonSizeY = newsButton.transform.localScale.y;
    }

    // Scales up the following buttons. Used for first half of pulse.
    protected override void scaleUpPanelButtons()
    {
        aAMButton.transform.localScale = new Vector2(aAMButtonSizeX + getButtonScaleIncrease(), aAMButtonSizeY + getButtonScaleIncrease());
        chirpButton.transform.localScale = new Vector2(chirpButtonSizeX + getButtonScaleIncrease(), chirpButtonSizeY + getButtonScaleIncrease());
        newsButton.transform.localScale = new Vector2(newsButtonSizeX + getButtonScaleIncrease(), newsButtonSizeY + getButtonScaleIncrease());
    }

    // Scales down the following buttons. Used for second half of pulse.
    protected override void scaleDownPanelButtons()
    {
        aAMButton.transform.localScale = new Vector2(aAMButtonSizeX, aAMButtonSizeY);
        chirpButton.transform.localScale = new Vector2(chirpButtonSizeX, chirpButtonSizeY);
        newsButton.transform.localScale = new Vector2(newsButtonSizeX, newsButtonSizeY);
    }

    // Closes all panels that are not the media panel. Used to avoid overlapping.
    private void CloseNonMediaPanels()
    {
        investigationPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        brycePanel.SetActive(false);
        webPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
}
