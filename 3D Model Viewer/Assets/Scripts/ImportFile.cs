using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using SFB;
using TMPro;
using UnityEngine.Networking;

public class ImportFile : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    public void OnClickOpen()
    {
        string[] paths = StandaloneFileBrowser.OpenFilePanel­­("Import File", "", "obj", false);
        if (paths.Length > 0)
        {
            StartCoroutine(OutputRoutineOpen(new System.Uri(paths[0]).AbsoluteUri));
        }
    }

    private IEnumerator OutputRoutineOpen(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("WWW ERROR" + www.error);
        } else
        {
            textMeshPro.text = www.downloadHandler.text;
        }
    }
}
