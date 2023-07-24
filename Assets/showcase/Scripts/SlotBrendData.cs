
using System.Collections.Generic;

[System.Serializable]
public class SlotDataRoot
{
    public List<SlotBrendData> slotBrendDatas { get; set; }
}

[System.Serializable]
public class SlotBrendData
{
    public string description { get; set; }
    public string button { get; set; }
    public string url { get; set; }
    public string img_logo { get; set; }
}
