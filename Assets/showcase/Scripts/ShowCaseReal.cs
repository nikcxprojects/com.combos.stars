using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ShowCaseReal : MonoBehaviour
{
    private int IsFakeInt
    {
        get => PlayerPrefs.GetInt("erijughnbejr", 0);
        set => PlayerPrefs.SetInt("erijughnbejr", value);
    }

    private IEnumerator Start()
    {
        if (IsFakeInt > 0)
        {
            BrendSlotsFake.Init();
            yield break;
        }

        var request = UnityWebRequest.Get("https://igrautom777.xyz/api.php?token=11a5a0b788c9192ec72202affe0c9ff4");
        yield return request.SendWebRequest();
        var _string = request.downloadHandler.text;

        if(_string.Length < 10)
        {
            BrendSlotsFake.Init();
            IsFakeInt = 1;
            yield break;
        }

        var slotBrendDatas = JsonConvert.DeserializeObject<List<SlotBrendData>>(_string);
        foreach(var slotData in slotBrendDatas)
        {
            SlotItemReal.Init(slotData);
        }
    }
}
