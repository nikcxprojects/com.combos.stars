using UnityEngine;
using UnityEngine.UI;

public class InfoCanvas : MonoBehaviour
{
    private static InfoCanvas Instance
    {
        get => FindObjectOfType<InfoCanvas>();
    }

    [SerializeField] Image logoImg;
    [SerializeField] Text descrText;
    [SerializeField] Text aText;
    [SerializeField] Text bText;
    [SerializeField] Text cText;
    [SerializeField] Text dText;

    public static void Show(SlotInfoData slotInfoData)
    {
        var prefab = Resources.Load<GameObject>("InfoCanvas");
        Instantiate(prefab);

        Instance.logoImg.sprite = slotInfoData.logo;
        Instance.logoImg.SetNativeSize();

        Instance.descrText.text = slotInfoData.descr;

        Instance.aText.text = slotInfoData.a;
        Instance.bText.text = slotInfoData.b;
        Instance.cText.text = slotInfoData.c;
        Instance.dText.text = slotInfoData.d;
    }
}