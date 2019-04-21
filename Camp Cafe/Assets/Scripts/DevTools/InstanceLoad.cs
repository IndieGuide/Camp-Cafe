using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceLoad : MonoBehaviour
{
    public static List<string[]> GetInstanceData(string textpath) {
        //读取文本
        string startStr = Resources.Load<TextAsset>(textpath).text;
        //去掉空格空行
        startStr = startStr.Replace(" ", "").Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n");
        //按行分割
        string[] allStr = startStr.Split('\n');

        List<string[]> dataList = new List<string[]>();
        foreach (string rowstr in allStr) {
            string[] insDataArr = rowstr.Split('|');
            dataList.Add(insDataArr);
        }
        return dataList;
    }
}
