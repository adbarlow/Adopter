using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace Adopter.View
{
    public partial class GalleryPage : ContentPage
    {
        int _index = 1;
        HttpClient _client = new HttpClient();
        UriImageSource _imageSource;
        List<Image> _dogList = new List<Image>();
        string dogAPI = "http://api.petfinder.com/breed.list?key=12603905e04249f8e42d23749e5a2067&animal=dog&format=json";

        public GalleryPage()
        {
            InitializeComponent();


            _imageSource = new UriImageSource { Uri = new Uri($"http://lorempixel.com/1920/1080/city/{_index}") };
            _imageSource.CachingEnabled = false;
            image.Source = _imageSource;
        }

        async void PreviousClicked(object sender, System.EventArgs e)
        {
            const string magicString = "article-content\"><img src=\"";

            var sourceStringImage = await _client.GetStringAsync(new Uri("http://dogtime.com/dog-breeds/bernese-mountain-dog"));
            var dogImageUrlIndexStart = sourceStringImage.IndexOf(magicString) + magicString.Length;
            var dogImageUrlIndexEnd = sourceStringImage.IndexOf('"', dogImageUrlIndexStart);
            var dogImageUrl = sourceStringImage.Substring(dogImageUrlIndexStart, dogImageUrlIndexEnd - dogImageUrlIndexStart);
            image.Source=dogImageUrl;

            //if (_index == 1)
            //{
            //    _index = 10;
            //}

            //image.Source = new UriImageSource { Uri = new Uri($"http://lorempixel.com/1920/1080/city/{_index--}") }; 
        }

        void NextClicked(object sender, System.EventArgs e)
        {
			if (_index == 10)
			{
				_index = 1;
			}
			image.Source = new UriImageSource { Uri = new Uri($"http://lorempixel.com/1920/1080/city/{_index++}") };
        }
    }
}
