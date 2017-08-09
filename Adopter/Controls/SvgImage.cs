using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace Adopter.Controls
{
    public class SvgImage : SKCanvasView
    {
        string _fileContent;

		public SvgImage()
		{
			PaintSurface += OnPaintSurface;
			HeightRequest = 40;
			WidthRequest = 40;

			GestureRecognizers.Add(new TapGestureRecognizer((obj) => Clicked?.Invoke(this, new EventArgs())));
		}

		public event EventHandler<EventArgs> Clicked;

		public static readonly BindableProperty ColorProperty =
			BindableProperty.Create(nameof(Color), typeof(Color), typeof(SvgImage), Color.White);

		public Color Color
		{
			get { return (Color)GetValue(ColorProperty); }
			set { SetValue(ColorProperty, value); }
		}

		public static readonly BindableProperty ImagePathProperty =
			BindableProperty.Create(nameof(ImagePath), typeof(string), typeof(SvgImage), null);

		public string ImagePath
		{
			get { return (string)GetValue(ImagePathProperty); }
			set { SetValue(ImagePathProperty, value); }
		}

		string GetContentFromFile()
		{
			var assembly = typeof(SvgImage).GetTypeInfo().Assembly;
			var name = assembly.ManifestModule.Name.Replace(".dll", string.Empty);
			var stream = assembly.GetManifestResourceStream($"{name}.Resources.{ImagePath}");

			string content;
			using (var reader = new StreamReader(stream))
			{
				content = reader.ReadToEnd();
			}

			return content;
		}

		void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
		{
			if (string.IsNullOrEmpty(ImagePath))
				return;

			try
			{
				if (_fileContent == null)
					_fileContent = GetContentFromFile();

				var svg = new SkiaSharp.Extended.Svg.SKSvg();
				var bytes = System.Text.Encoding.UTF8.GetBytes(_fileContent);
				var stream = new MemoryStream(bytes);

				svg.Load(stream);
				var canvas = e.Surface.Canvas;
				using (var paint = new SKPaint())
				{
					//Set the paint color
					paint.ColorFilter = SKColorFilter.CreateBlendMode(Color.ToSKColor(), SKBlendMode.SrcIn);

					//Scale up the SVG image to fill the canvas
					float canvasMin = Math.Min(e.Info.Width, e.Info.Height);
					float svgMax = Math.Max(svg.Picture.CullRect.Width, svg.Picture.CullRect.Height);
					float scale = canvasMin / svgMax;
					var matrix = SKMatrix.MakeScale(scale, scale);

					canvas.Clear(Color.Transparent.ToSKColor());
					canvas.DrawPicture(svg.Picture, ref matrix, paint);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error drawing SvgImage w/ ImagePath {ImagePath}: {ex}");
			}
		}
    }
}
