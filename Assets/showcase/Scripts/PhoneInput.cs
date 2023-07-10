using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PhoneInput : MonoBehaviour
{
    private InputField InputField { get; set; }
    private void Awake()
    {
        InputField = GetComponent<InputField>();
    }

    private void Start()
    {
        InputField.onValueChanged.AddListener(FormatPhoneNumber);
    }

    public void FormatPhoneNumber(string input)
    {
        // Удалить все символы, кроме цифр
        string cleanedNumber = new string(System.Text.RegularExpressions.Regex.Replace(input, @"[^\d]", "").ToCharArray());

        // Проверить, что номер телефона имеет достаточное количество цифр
        if (cleanedNumber.Length >= 11)
        {
            // Добавить префикс "+" и код страны "7"
            var cleanedNumberFirst = $"+{cleanedNumber.Substring(0, 1)} {cleanedNumber.Substring(1, 3)} ";

            // Добавить остальную часть номера телефона
            if (cleanedNumber.Length >= 9)
            {
                //89996394765
                cleanedNumber = cleanedNumberFirst + $"{cleanedNumber.Substring(4, 3)}-{cleanedNumber.Substring(7,2)}-{cleanedNumber.Substring(9)}";
            }

            InputField.text = cleanedNumber;
        }
    }
}
