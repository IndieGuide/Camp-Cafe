using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCollection
{
    public static Color GetVecNormal() {
        return new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 255 / 255.0f);
    }
    
    public static Color GetVecClear() {
        return new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 0 / 255.0f);
    }
    public static Color GetVecGrey() {
        return new Color(128 / 255.0f, 128 / 255.0f, 128 / 255.0f, 255 / 255.0f);
    }

    internal static Color GetVecGreyWithAlpha() {
        return new Color(0.0f/255.0f, 0.0f / 255.0f, 0.0f / 255.0f, 70.0f / 255.0f);
    }
    internal static Color GetVecGreyEnter() {
        return new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f, 30.0f / 255.0f);
    }
}
