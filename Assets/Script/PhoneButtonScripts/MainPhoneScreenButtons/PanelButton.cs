using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButton : PhoneButton
{
    public GameObject pnlToOpen;
    public GameObject[] pnlsToClose;
    public GameObject[] pnlBtns;

    private float[] btnSizeX;
    private float[] btnSizeY;

    private const float pulseDelay = .01f;
    private const float btnScaleIncrease = .1f;

    public override void OnClickEvent()
    {
        if (pnlToOpen.activeSelf) { pnlToOpen.SetActive(false); }
        else { pnlToOpen.SetActive(true); closePnlsPulseBtns(); }
    }

    private void closePnlsPulseBtns()
    {
        CloseUIPanels();
        GetButtonDimensions();
        StartCoroutine("Pulse");
    }

    private void CloseUIPanels()
    {
        for (int pI = 0; pI < pnlsToClose.Length; pI++) { pnlsToClose[pI].SetActive(false); }
    }

    private IEnumerator Pulse()
    {
        yield return new WaitForSeconds(pulseDelay);
        scaleUpPanelButtons();

        yield return new WaitForSeconds(pulseDelay);
        scaleDownPanelButtons();
    }

    //Obtains the dimensions of each panel button.
    private void GetButtonDimensions()
    {
        btnSizeX = new float[pnlBtns.Length];
        btnSizeY = new float[pnlBtns.Length];

        for (int bI = 0; bI < pnlBtns.Length; bI++)
        {
            btnSizeX[bI] = pnlBtns[bI].transform.localScale.x;
            btnSizeY[bI] = pnlBtns[bI].transform.localScale.y;
        }
    }

    // Scales up the following buttons. Used for first half of pulse.
    private void scaleUpPanelButtons()
    {
        for (int bI = 0; bI < pnlBtns.Length; bI++) { pnlBtns[bI].transform.localScale = new Vector2(btnSizeX[bI] + btnScaleIncrease, btnSizeY[bI] + btnScaleIncrease); }
    }

    // Scales down the following buttons. Used for second half of pulse.
    private void scaleDownPanelButtons()
    {
        for (int bI = 0; bI < pnlBtns.Length; bI++) { pnlBtns[bI].transform.localScale = new Vector2(btnSizeX[bI], btnSizeY[bI]); }
    }
}