using UnityEngine;

[CreateAssetMenu()]
public class SlotInfoData : ScriptableObject
{
    public Sprite logo;

    [TextArea]
    public string descr;

    [Space(10), TextArea]
    public string a;

    [Space(10), TextArea]
    public string b;

    [Space(10), TextArea]
    public string c;

    [Space(10), TextArea]
    public string d;
}
