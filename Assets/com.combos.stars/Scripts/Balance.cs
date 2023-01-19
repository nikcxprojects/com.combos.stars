using UnityEngine;
using UnityEngine.UI;

public class Balance : MonoBehaviour
{
    Text textComponent;
    private const string key = "balance";

    private int Count
    {
        get => PlayerPrefs.GetInt(key, 1000);
        set => PlayerPrefs.SetInt(key, value);
    }

    private void Awake()
    {
        textComponent = GetComponent<Text>();
        textComponent.text = $"{Count}";
    }

    private void OnEnable()
    {
        Manager.OnEndRolling += BalanceHandlerSlots;
        WheelSpinner.OnEndRolling += BalanceHandlerWheel;

        textComponent.text = $"{Count}";
    }

    private void OnDisable()
    {
        Manager.OnEndRolling -= BalanceHandlerSlots;
        WheelSpinner.OnEndRolling -= BalanceHandlerWheel;
    }

    private void BalanceHandlerSlots(int value)
    {
        Count += value;
        textComponent.text = $"{Count}";

        Instantiate(Resources.Load<GameObject>("popup"), GameObject.Find("main canvas").transform);
    }

    private void BalanceHandlerWheel(int value)
    {
        Count += value;
        textComponent.text = $"{Count}";

        Instantiate(Resources.Load<GameObject>("popup"), GameObject.Find("main canvas").transform);
    }
}