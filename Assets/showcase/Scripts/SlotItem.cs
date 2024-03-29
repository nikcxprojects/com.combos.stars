using UnityEngine;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{
    [SerializeField] SlotInfoData slotInfoData;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            InfoCanvas.Show(slotInfoData);
        });
    }
}
