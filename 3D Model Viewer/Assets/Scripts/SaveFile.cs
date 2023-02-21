using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SFB;
using System;
using TMPro;

public class SaveFile : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    
    public void OnClickSave()
    {
        string path = StandaloneFileBrower.SaveFilePanel("Save File", "", "model", "obj");
        if (!string.IsNullOrEmpty(path))
        {
            File.WriteAllText(path, textMeshPro.text);
        }
    }
}
