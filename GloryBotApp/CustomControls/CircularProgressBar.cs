using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using System;
using Avalonia.Controls.Primitives;

namespace GloryBotApp.CustomControls;

public class CircularProgressBar : Control
{
    private double _maxValue = 100;
    private double _value = 0.0;

    private IBrush _centerbackround;

    public static readonly DirectProperty<CircularProgressBar, IBrush> CenterBackgroundProperty = AvaloniaProperty.RegisterDirect<CircularProgressBar, IBrush>(
        nameof(CenterBackground), 
        o => o.CenterBackground,
        (o, v) => o.CenterBackground = v);

    public IBrush CenterBackground
    {
        get => _centerbackround;
        set => SetAndRaise(CenterBackgroundProperty, ref _centerbackround, value);
    }

    public static readonly DirectProperty<CircularProgressBar, double> ValueProperty =
        AvaloniaProperty.RegisterDirect<CircularProgressBar, double>(
            nameof(Value),
            o => o.Value,
            (o, v) => o.Value = v,
            enableDataValidation: false);


    public static readonly DirectProperty<CircularProgressBar, double> MaxValueProperty = AvaloniaProperty.RegisterDirect<CircularProgressBar, double>(
        nameof(MaxValue),
        o => o.MaxValue,
        (o, v) => o.MaxValue = v
        );

    public double MaxValue
    {
        get => _maxValue;
        set => SetAndRaise(MaxValueProperty, ref _maxValue, value);
    }
    
    public double Value
    {
        get => _value;
        set => SetAndRaise(ValueProperty, ref _value, value);
    }
    

    public override void Render(DrawingContext context)
    {
        var outerRadius = Math.Min(Bounds.Width, Bounds.Height) / 2;
        var innerRadius = outerRadius * 0.75;
        var center = new Point(Bounds.Width / 2, Bounds.Height / 2);
        var progressAngle = 360 * (Value / MaxValue);

        var backgroundBrush = new SolidColorBrush(Colors.LightGray);
        var foregroundBrush = new SolidColorBrush(Colors.Blue);

        context.DrawEllipse(backgroundBrush, null, center, outerRadius, outerRadius);
        context.DrawEllipse(CenterBackground, null, center, innerRadius, innerRadius);

        var endPoint = new Point(center.X + outerRadius * Math.Cos(progressAngle * Math.PI / 180),
            center.Y - outerRadius * Math.Sin(progressAngle * Math.PI / 180));

        var pathGeometry = new PathGeometry();
        var pathFigure = new PathFigure
        {
            StartPoint = center,
            IsClosed = true
        };
        pathFigure.Segments.Add(new LineSegment { Point = center });
        pathFigure.Segments.Add(new LineSegment { Point = endPoint });
        pathGeometry.Figures.Add(pathFigure);

        context.DrawGeometry(foregroundBrush, null, pathGeometry);
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        var diameter = Math.Min(availableSize.Width, availableSize.Height);
        return new Size(diameter, diameter);
    }
}