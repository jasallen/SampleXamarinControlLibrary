using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using CustomControlsLibrary.Base;
using CustomControls.UWP;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace CustomControls.UWP
{


    public class CustomPickerRenderer : PickerRenderer
    {
       
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
    

            //// Ensure the control isn't instantiated more than once
            //if (!(Control is null)) return;



            // Create a new platform-specific native control and assign it to the Control property
            //_nativeControl = new ComboBox();
            //base.SetNativeControl(_nativeControl);

           
            // Copy the items source info into the native control from the Xamarin Forms element
            //_nativeControl.ItemsSource = e.NewElement.ItemsSource;


            // Subscribe to the Xamarin Forms custom control's picklist opened event,
            // redirecting to a platform-specific event handler
            (e.NewElement as CustomPicker).PickListOpened += OnOpenPickList;
        }



        // Triggered by the solution-level OpenPickList method to create a functional equivalent of the Xamarin Forms
        // .Focus() method that works consistently across Android, iOS and UWP to open the picker's list.
        // The .Focus() method doesn't open the UWP picker's list since UWP isn't a touch-only interface.
        private void OnOpenPickList(object sender, EventArgs e)
        {
            // The Windows ComboBox's .IsDropDownOpen property controls the picklist visibility in UWP
            Control.IsDropDownOpen = true;
        }
    }


}
