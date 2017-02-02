using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapNode : PhoneButton
{
    public YesButton yesButton;
    public GameObject informationPanel;
    public GameObject travelToPanel;
    public Image locationImage;
    public Sprite desiredLocationImage;
    public Text locationPreviewTextBox;
    public Text locationInformationTextBox;
    public Text distanceToTextBox;
    public Text travelTimeTextBox;
    public string locationName;
    public string locationInformation;

    private bool isCurrentLocation;
    private float distanceFromCurrentLocation;

    // Constant used in calculating the time to travel to a new location.
    private const float SIXTY_MIN_OR_SEC = 60.0f;

    public override void OnClickEvent()
    {
        OpenInformationPanel();
        CloseTravelToPanel();
        DisplayInformation();
        SendInformationToYesButton();
    }

    // Opens the information panel.
    private void OpenInformationPanel() { informationPanel.SetActive(true); }

    // Decides whether to close the TravelTo panel or not depending on if the selected node is the current* node or not.
        // *Where the player is currently located.
    private void CloseTravelToPanel()
    {
        if(isCurrentLocation) { travelToPanel.SetActive(false); }
        else { travelToPanel.SetActive(true); }
    }

    // Displays the selected locations photo, name, information, distance from the player's current location, and the time need to travel to the selected location
        // to various game objects in the information panel.
    private void DisplayInformation()
    {
        locationImage.sprite = desiredLocationImage;
        locationPreviewTextBox.text = locationName;
        locationInformationTextBox.text = locationInformation;

        // If the selected node is the current location, display the following information.
        if(isCurrentLocation)
        {
            distanceToTextBox.text = "Distance to: You are already here!";
            travelTimeTextBox.text = "Travel time: N/A";
        }
        // Else display the following information.
        else
        {
            distanceToTextBox.text = "Distance to: " + distanceFromCurrentLocation.ToString() + " mi";
            travelTimeTextBox.text = "Travel Time: " + CalculateTravelTime();
        }
    }

    
    // Calculates the time needed to travel to another location in hours and minutes.
    private string CalculateTravelTime()
    {
        float rawHours = distanceFromCurrentLocation / SIXTY_MIN_OR_SEC;
        int hours = (int) rawHours;
        float rawMinutes = (rawHours - hours) * 60;
        int minutes = (int) rawMinutes;

        return hours + " hr(s) " + minutes + " min(s)";
    }

    // Assigns this mapNode as the current node (or current place the player is located).
    public void AssignAsCurrentLocation() { isCurrentLocation = true; }

    // Sets the distance of the selected city from the player's current location.
    public void setDistanceFromCurrentLocation(float newDistance) { distanceFromCurrentLocation = newDistance; }

    // Sends the selected location's name to the yes button in case the player wants to travel to the selected location.
    private void SendInformationToYesButton() { yesButton.setDestination(locationName); }
}
