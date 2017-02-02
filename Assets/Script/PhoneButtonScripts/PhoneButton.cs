using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent script for every button on the main cell phone screen.
/// </summary>
public class PhoneButton : MonoBehaviour
{
    // To be implemented within child classes.
    public virtual void OnClickEvent() { Debug.Log("Button pressed"); }
}
