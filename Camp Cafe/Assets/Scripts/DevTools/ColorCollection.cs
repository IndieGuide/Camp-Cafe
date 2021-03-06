﻿using System;
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

    internal static Color GetRandomGoodColor() {
        Color col1 = new Color(254f/255f,67f/255f,101f/255f);
        Color col2 = new Color(252f/255f,157f/255f,154f/255f);
        Color col3 = new Color(249f/255f,205f/255f,173f/255f);
        Color col4 = new Color(200f/255f,200f/255f,169f/255f);
        Color col5 = new Color(131f/255f,175f/255f,155f/255f);
        Color col6 = new Color(0f/255f,246f/255f,255f/255f);
        Color col7 = new Color(0f/255f,255f/255f,146f/255f);
        Color col8 = new Color(0f/255f,255f/255f,146f/255f);
        Color col9 = new Color(178f/255f,0f/255f,255f/255f);
        List<Color> colList = new List<Color>() {
            col1,col2,col3,col4,col5,col6,col7,col8,col9
        };
        return colList[UnityEngine.Random.Range(0,8)];
    }

    internal static Color GetVecGreyEnter() {
        return new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f, 30.0f / 255.0f);
    }
    /// <summary>
    /// color 转换hex
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static string ColorToHex(Color color) {
        int r = Mathf.RoundToInt(color.r * 255.0f);
        int g = Mathf.RoundToInt(color.g * 255.0f);
        int b = Mathf.RoundToInt(color.b * 255.0f);
        int a = Mathf.RoundToInt(color.a * 255.0f);
        string hex = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", r, g, b, a);
        return hex;
    }

    /// <summary>
    /// hex转换到color
    /// </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    public static Color HexToColor(string hex) {
        byte br = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte bg = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte bb = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        float r = br / 255f;
        float g = bg / 255f;
        float b = bb / 255f;

        return new Color(r, g, b);
    }

    public static Color ColorMix(Color colora, Color colorb) {
        Color resultColor = new Color();
        resultColor.r = ColorCellMix(colora.r, colorb.r);
        resultColor.g = ColorCellMix(colora.g, colorb.g);
        resultColor.b = ColorCellMix(colora.b, colorb.b);
        resultColor.a = 1.0f;
        return resultColor;
    }
    public static float ColorCellMix(float a, float b) {
        //线性光算法
        a = a*255;
        b = b*255;
        float result = b >= 128 ? Math.Max(a, (b - 128) * 2) : Math.Min(a, b * 2);
        result = result / 255;
        //Debug.Log("result:"+result);
        return result;
    }


}
