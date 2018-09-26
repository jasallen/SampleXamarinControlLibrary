using System;
using Xamarin.Forms;

namespace CustomControlsLibrary.Base
{
    public class CustomPicker : Picker
    {
        public EventHandler PickListOpened;
        
        // Method to create a functional equivalent of the Xamarin Forms .Focus() method that
        // works consistently across Android, iOS and UWP to open the picker's list. The .Focus()
        // method doesn't open the UWP picker's list since UWP isn't a touch-only interface.
        public void OpenPickList()
        {
            // For UWP, kick off an event for a subscribed custom renderer to open the picker list
            if (Device.RuntimePlatform == Device.UWP)
            {
                PickListOpened?.Invoke(this, new EventArgs());
            }

            // For other platforms, the Xamarin Forms picker's .Focus() method opens the picker list
            else
            {
                this.Focus();
            }
        }

    }
}
