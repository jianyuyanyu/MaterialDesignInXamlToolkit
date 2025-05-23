﻿using System.ComponentModel;
using System.Windows.Media;

namespace MaterialDesignThemes.Wpf;

public class CustomColorTheme : ResourceDictionary, IMaterialDesignThemeDictionary
{
    private BaseTheme? _baseTheme;
    public BaseTheme? BaseTheme
    {
        get => _baseTheme;
        set
        {
            if (_baseTheme != value)
            {
                _baseTheme = value;
                SetTheme();
            }
        }
    }

    private Color? _primaryColor;
    [TypeConverter(typeof(InheritSystemColorTypeConverter))]
    public Color? PrimaryColor
    {
        get => _primaryColor;
        set
        {
            if (_primaryColor != value)
            {
                _primaryColor = value;
                SetTheme();
            }
        }
    }

    private Color? _secondaryColor;
    [TypeConverter(typeof(InheritSystemColorTypeConverter))]
    public Color? SecondaryColor
    {
        get => _secondaryColor;
        set
        {
            if (_secondaryColor != value)
            {
                _secondaryColor = value;
                SetTheme();
            }
        }
    }

    private ColorAdjustment? _colorAdjustment;
    public ColorAdjustment? ColorAdjustment
    {
        get => _colorAdjustment;
        set
        {
            if (_colorAdjustment != value)
            {
                _colorAdjustment = value;
                SetTheme();
            }
        }
    }

    private void SetTheme()
    {
        if (BaseTheme is BaseTheme baseTheme &&
            PrimaryColor is Color primaryColor &&
            SecondaryColor is Color secondaryColor)
        {
            var theme = Theme.Create(baseTheme, primaryColor, secondaryColor);
            theme.ColorAdjustment = ColorAdjustment;
            ApplyTheme(theme);
        }
    }

    protected virtual void ApplyTheme(Theme theme) =>
        this.SetTheme(theme);
}
