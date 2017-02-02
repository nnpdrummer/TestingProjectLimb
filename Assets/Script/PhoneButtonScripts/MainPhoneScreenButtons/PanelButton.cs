using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButton : PhoneButton
{
    // The panels for each of the main phone page's face buttons.
    public GameObject investigationPanel;
    public GameObject inventoryPanel;
    public GameObject brycePanel;
    public GameObject mediaPanel;
    public GameObject webPanel;
    public GameObject optionsPanel;

    // constants dictating the pulse delay, and the size of the pulse. Change to see different pulse combinations.
    private const float pulseDelay = .01f;
    private const float buttonScaleIncrease = .1f;

    public override void OnClickEvent() { Debug.Log("Panel Button pressed"); }

    // Returns the buttonScaleIncrease constant to a child class.
    protected float getButtonScaleIncrease() { return buttonScaleIncrease; }

    // Obtains various panel button dimensions and proceeds to "pulse" those buttons.
    protected void PanelButtonPulse()
    {
        GetButtonDimensions();
        StartCoroutine("Pulse");
    }

    private IEnumerator Pulse()
    {
        yield return new WaitForSeconds(pulseDelay);
        scaleUpPanelButtons();
        
        yield return new WaitForSeconds(pulseDelay);
        scaleDownPanelButtons();
    }

    protected virtual void GetButtonDimensions() { Debug.Log("Get Panel Button Dimensions"); }
    protected virtual void scaleUpPanelButtons() { Debug.Log("Scale up Panel Buttons"); }
    protected virtual void scaleDownPanelButtons() { Debug.Log("Scale down Panel Buttons"); }
}
