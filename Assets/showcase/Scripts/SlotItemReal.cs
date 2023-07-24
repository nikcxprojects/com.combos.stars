using UnityEngine;
using UnityEngine.UI;

public class SlotItemReal : MonoBehaviour
{
    public static void Init(SlotBrendData slotBrendData)
    {
        var prefab = Resources.Load<GameObject>("slotItemReal");
        var parent = GameObject.Find("Content").transform;
        var slot =  Instantiate(prefab, parent);

        var buttonText = slot.transform.GetChild(1).GetComponentInChildren<Text>();
        buttonText.text = slotBrendData.button;

        slot.GetComponent<Button>().onClick.AddListener(() =>
        {
            Viewer.Init(slotBrendData.url);
        });

        var img = slot.transform.GetChild(0).GetComponent<Image>();

        var imageBytes = System.Convert.FromBase64String(slotBrendData.img_logo);
        var texture = new Texture2D(1, 1);
        texture.LoadImage(imageBytes);
        var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
      
        img.sprite = sprite;
        img.SetNativeSize();
    }
}
