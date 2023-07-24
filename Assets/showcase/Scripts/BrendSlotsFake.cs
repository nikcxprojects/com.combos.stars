using UnityEngine;

public class BrendSlotsFake : MonoBehaviour
{
    public static void Init()
    {
        Destroy(GameObject.Find("BrendSlots"));
        var prefab = Resources.Load<GameObject>("BrendSlotsFake");
        var parent = GameObject.Find("Canvas").transform;
        Instantiate(prefab, parent);
    }
}
