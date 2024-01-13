using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class EquipWindowManager : MonoBehaviour
{
    [SerializeField] private EquipImage[] sm_equip_rings;

    WWWForm form;
    private OCID ocid;
    private DateTime time;

    private EquipmentInfo equipmentInfo;
    private ErrorMessage errormessage;

    private void Awake()
    {
        form = new WWWForm();
        time = DateTime.Now;

        // Debug.Log((time - time.AddDays(-5)).Days);
    }

    private void Start()
    {
        form.AddField("x-nxopen-api-key", "test_b66d0efebcd772af61baab7453dcac6fdf3255c40690b9d1c25127b5c2ee5e24a137f7efda47f8eaebd2d0d4cea49bda");
    }

    public void GetUserItemInfo(string nickname)
    {
        StartCoroutine(GetUserOCID(nickname));
    }

    private IEnumerator GetUserEquipmentInfo()
    {
        UnityWebRequest www = UnityWebRequest.Get(string.Format("{0}{1}{2}{3}", "https://open.api.nexon.com/maplestory/v1/character/item-equipment?ocid=", ocid.ocid, "&date=", time.ToString("yyyy-MM-dd")));
        
        www.SetRequestHeader("x-nxopen-api-key", "test_b66d0efebcd772af61baab7453dcac6fdf3255c40690b9d1c25127b5c2ee5e24a137f7efda47f8eaebd2d0d4cea49bda");
        
        yield return www.SendWebRequest();

        if (www.error == null)
        {
            equipmentInfo = JsonUtility.FromJson<EquipmentInfo>(www.downloadHandler.text);
            for(int i=0;i<sm_equip_rings.Length;i++)
            {
                if (equipmentInfo.item_equipment[i] != null)
                {
                    sm_equip_rings[i].SetImage(equipmentInfo.item_equipment[i].item_shape_name,
                        equipmentInfo.item_equipment[i].item_icon,
                        equipmentInfo.item_equipment[i].starforce,
                        equipmentInfo.item_equipment[i].item_base_option.base_equipment_level);
                }
                else
                {
                    sm_equip_rings[i].SetImage(null);
                }
            }
        }
        else
        {
            errormessage = JsonUtility.FromJson<ErrorMessage>(www.downloadHandler.text);
            if(errormessage.error.name == "OPENAPI00004")
            {
                Debug.LogError("날짜안맞음");
                time = time.AddDays(-1);
                StartCoroutine(GetUserEquipmentInfo());
            }
        }
    }

    private IEnumerator GetUserOCID(string nickname)
    {
        UnityWebRequest www = UnityWebRequest.Get(string.Format("{0}{1}", "https://open.api.nexon.com/maplestory/v1/id?character_name=", nickname));
        www.SetRequestHeader("x-nxopen-api-key", "test_b66d0efebcd772af61baab7453dcac6fdf3255c40690b9d1c25127b5c2ee5e24a137f7efda47f8eaebd2d0d4cea49bda");
        yield return www.SendWebRequest();

        if (www.error == null)
        {
            Debug.Log(www.downloadHandler.text);
            ocid = JsonUtility.FromJson<OCID>(www.downloadHandler.text);
            StartCoroutine(GetUserEquipmentInfo());
        }
        else
            Debug.LogError("에러발생");
    }
}
