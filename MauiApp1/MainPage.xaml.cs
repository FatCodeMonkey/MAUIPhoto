
namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
        MyImage.Source = Path.Combine(FileSystem.AppDataDirectory, "0f86e13d9b8b454b90306738ea5d7b28.jpg");
         
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

        TakePhoto();


        //SemanticScreenReader.Announce(CounterBtn.Text);
	}

    public async void TakePhoto()
    {
        //Microsoft.Maui.
        //Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        //string mainDir = FileSystem.Current.AppDataDirectory;
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                // save the file into local storage
                //string localFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), photo.FileName);
                string localFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);

                

            }
        }
    }

}

