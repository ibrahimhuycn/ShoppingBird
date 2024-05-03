
using System.Windows.Input;

namespace ShoopingBird.Maui.Controls;

public partial class ImageButton : ContentView
{
    public ImageButton()
	{
		InitializeComponent();
        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += OnTapped;
        this.GestureRecognizers.Add(tapGestureRecognizer);
    }

    #region Caption

    public static readonly BindableProperty CaptionProperty = BindableProperty.Create(nameof(Caption), typeof(string), typeof(ImageButton), propertyChanged: CaptionPropertyChanged);
    private static void CaptionPropertyChanged(BindableObject bindableSender, object oldValue, object newValue)
    {
        var imageButton = (ImageButton)bindableSender;
        imageButton.CaptionLabel.Text = newValue as string;
    }

    public string? Caption
    {
        get => GetValue(CaptionProperty) as string; 
        set
        {
            SetValue(CaptionProperty, value);
        }
    }

    #endregion

    #region Image Source

    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(ImageButton), propertyChanged: ImageSourcePropertyChanged);
    private static void ImageSourcePropertyChanged(BindableObject bindableSender, object oldValue, object newValue)
    {
        var imageButton = (ImageButton)bindableSender;
        imageButton.ButtonImage.Source = newValue as string;
    }
    public string ImageSource { get; set; }

    #endregion

    #region Tapped Command

    public static readonly BindableProperty TappedCommandProperty =
        BindableProperty.Create(nameof(TappedCommand), typeof(ICommand), typeof(ImageButton), default(ICommand));

    public ICommand? TappedCommand
    {
        get => GetValue(TappedCommandProperty) as ICommand;
        set => SetValue(TappedCommandProperty, value);
    }

    public static readonly BindableProperty TappedCommandParameterProperty =
        BindableProperty.Create(nameof(TappedCommandParameter), typeof(object), typeof(ImageButton), null);

    public object TappedCommandParameter
    {
        get => GetValue(TappedCommandParameterProperty);
        set => SetValue(TappedCommandParameterProperty, value);
    }
    private void OnTapped(object? sender, EventArgs e)
    {
        if (TappedCommand != null && TappedCommand.CanExecute(TappedCommandParameter))
        {
            TappedCommand.Execute(TappedCommandParameter);
        }
    }
    #endregion

}