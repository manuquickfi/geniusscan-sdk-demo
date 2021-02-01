using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Text.Json;

namespace SimpleDemo.Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void StartScanning(object sender, EventArgs args)
        {
            //var configuration = new Dictionary<string, object>();
            //configuration["source"] = "camera";
            //configuration["multiPage"] = true;
            //configuration["defaultFilter"] = "blackAndWhite";
            //configuration["pdfMaxScanDimension"] = 2000;
            //configuration["postProcessingActions"] = new String[] { "rotate", "editFilter" };
            
            IScanFlow scanFlow = DependencyService.Get<IScanFlow>();
            try
            {
                var pdfUrl = await scanFlow.StartScanning();

                //var jsonResult = await scanFlow.StartScanning(JsonSerializer.Serialize(configuration));
                //var result = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonResult);
                //var pdfUrl = (string)result["pdfUrl"];

                await Share.RequestAsync(new ShareFileRequest
                {
                    File = new ShareFile(new Uri(pdfUrl).AbsolutePath),
                    Title = "Share PDF document"
                });
            } catch (Exception e)
            {
                await DisplayAlert("Alert", "Error: " + e.Message, "OK");
            }
        }
    }
}
