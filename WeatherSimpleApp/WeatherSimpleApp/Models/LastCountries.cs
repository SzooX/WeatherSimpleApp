using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;

namespace WeatherSimpleApp.Models
{
    class LastCountries
    {
        public string lastCountry1 = String.Empty;
        public string lastCountry2 = String.Empty;
        public string lastCountry3 = String.Empty;

        IFolder rootFolder = FileSystem.Current.LocalStorage;
        IFolder folder;
        IFile last1;
        IFile last2;
        IFile last3;

        public LastCountries()
        {
            SetPaths();
        }

        async Task SetPaths()
        {
            rootFolder = FileSystem.Current.LocalStorage;
            folder = await rootFolder.CreateFolderAsync("LocalData", CreationCollisionOption.OpenIfExists);
            last1 = await folder.CreateFileAsync("lastCountry1.txt", CreationCollisionOption.OpenIfExists);
            last2 = await folder.CreateFileAsync("lastCountry2.txt", CreationCollisionOption.OpenIfExists);
            last3 = await folder.CreateFileAsync("lastCountry3.txt", CreationCollisionOption.OpenIfExists);
        }

        public async Task LoadFromDevice()
        {
            lastCountry1 = await last1.ReadAllTextAsync();
            lastCountry2 = await last2.ReadAllTextAsync();
            lastCountry3 = await last3.ReadAllTextAsync();
        }

        public async Task SaveToDevice()
        {
            await last1.WriteAllTextAsync(lastCountry1);
            await last2.WriteAllTextAsync(lastCountry2);
            await last3.WriteAllTextAsync(lastCountry3);
        }
    }
}
