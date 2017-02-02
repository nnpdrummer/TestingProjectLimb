using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebButton : PanelButton
{
    // The buttons that appear when the web button is clicked (or hovered over).
    public GameObject searchButton;
    public GameObject artButton;
    public GameObject tuneTaterButton;
    public GameObject meme_OButton;

    // Used to make the "pulse" effect on the above buttons.
    private float searchButtonSizeX;
    private float searchButtonSizeY;
    private float artButtonSizeX;
    private float artButtonSizeY;
    private float tuneTaterButtonSizeX;
    private float tuneTaterButtonSizeY;
    private float meme_OButtonSizeX;
    private float meme_OButtonSizeY;

    public override void OnClickEvent()
    {
        // Opens or closes the web panel depending if it is closed or open.
        if (webPanel.activeSelf) { webPanel.SetActive(false); }
        else { webPanel.SetActive(true); PanelButtonPulse(); }

        // Closes all of the non web panels.
        CloseNonWebPanels();
    }

    // Obtains the dimensions of the web panel's buttons.
    protected override void GetButtonDimensions()
    {
        searchButtonSizeX = searchButton.transform.localScale.x;
        searchButtonSizeY = searchButton.transform.localScale.y;
        artButtonSizeX = artButton.transform.localScale.x;
        artButtonSizeY = artButton.transform.localScale.y;
        tuneTaterButtonSizeX = tuneTaterButton.transform.localScale.x;
        tuneTaterButtonSizeY = tuneTaterButton.transform.localScale.y;
        meme_OButtonSizeX = meme_OButton.transform.localScale.x;
        meme_OButtonSizeY = meme_OButton.transform.localScale.y;
    }

    // Scales up the following buttons. Used for first half of pulse.
    protected override void scaleUpPanelButtons()
    {
        searchButton.transform.localScale = new Vector2(searchButtonSizeX + getButtonScaleIncrease(), searchButtonSizeY + getButtonScaleIncrease());
        artButton.transform.localScale = new Vector2(artButtonSizeX + getButtonScaleIncrease(), artButtonSizeY + getButtonScaleIncrease());
        tuneTaterButton.transform.localScale = new Vector2(tuneTaterButtonSizeX + getButtonScaleIncrease(), tuneTaterButtonSizeY + getButtonScaleIncrease());
        meme_OButton.transform.localScale = new Vector2(meme_OButtonSizeX + getButtonScaleIncrease(), meme_OButtonSizeY + getButtonScaleIncrease());
    }

    // Scales down the following buttons. Used for second half of pulse.
    protected override void scaleDownPanelButtons()
    {
        searchButton.transform.localScale = new Vector2(searchButtonSizeX, searchButtonSizeY);
        artButton.transform.localScale = new Vector2(artButtonSizeX, artButtonSizeY);
        tuneTaterButton.transform.localScale = new Vector2(tuneTaterButtonSizeX, tuneTaterButtonSizeY);
        meme_OButton.transform.localScale = new Vector2(meme_OButtonSizeX, meme_OButtonSizeY);
    }

    // Closes all panels that are not the web panel. Used to avoid overlapping.
    private void CloseNonWebPanels()
    {
        investigationPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        brycePanel.SetActive(false);
        mediaPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
}
