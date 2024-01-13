using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class EquipImage : MonoBehaviour
{
    // private string url = "https://open.api.nexon.com/static/maplestory/ItemIcon/KEOAJEJF.png";
    private RawImage rawImage;

    private ItemInfo itemInfo;

    private void Awake()
    {
        rawImage = GetComponent<RawImage>();
    }

    void Start()
    {
    }

    IEnumerator GetTexture(string url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            rawImage.texture = myTexture;
        }
    }

    public void SetImage(string itemName, string itemURL, string starforce, string level)
    {
        rawImage.enabled = true;
        itemInfo = new ItemInfo(itemName, itemURL, starforce, level);
        StartCoroutine(GetTexture(itemInfo.GetItemURL()));
    }

    public void SetImage(string itemName)
    {
        rawImage.enabled = false;
    }
}

