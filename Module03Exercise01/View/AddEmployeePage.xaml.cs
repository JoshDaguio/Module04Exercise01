namespace Module03Exercise01.View;

public partial class AddEmployeePage : ContentPage
{
	public AddEmployeePage()
	{
		InitializeComponent();
	}

    private async void OnGetLocationClicked(object sender, EventArgs e)
    {
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.High
                });
            }
            if (location != null)
            {
                LocationLabel.Text = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}";

                // Get Geocoding - Get Address from Lat and Long
                var placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);

                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    // Use the text typed by the user in the entry fields
                    var municipality = MunicipalityEntry.Text; // User input for Municipality
                    var province = ProvinceEntry.Text; // User input for Province

                    // If no user input, fallback to placemark values
                    if (string.IsNullOrWhiteSpace(municipality))
                    {
                        municipality = placemark.Locality;
                    }
                    if (string.IsNullOrWhiteSpace(province))
                    {
                        province = placemark.AdminArea;
                    }

                    AddressLabel.Text = $"Address: {placemark.Thoroughfare}, " +
                        $"{municipality}, " +  // Municipality from user input or placemark
                        $"{province}, " +  // Province from user input or placemark
                        $"{placemark.PostalCode}, " +
                        $"{placemark.CountryName}";
                }
                else
                {
                    AddressLabel.Text = "Unable to determine the address";
                }
            }
            else
            {
                LocationLabel.Text = "Unable to get location";
            }
        }
        catch (Exception ex)
        {
            LocationLabel.Text = $"Error: {ex.Message}";
        }
    }



    private async void OnCapturePhotoClicked(object sender, EventArgs e)
    {
        try
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                //Capture a pohoto using MediaPicker
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    await LoadPhotoAsync(photo);
                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occured: {ex.Message}", "OK");
        }
    }
    private async Task LoadPhotoAsync(FileResult photo)
    {
        if (photo == null)
            return;

        Stream stream = await photo.OpenReadAsync();

        CaptureImage.Source = ImageSource.FromStream(() => stream);
    }
}