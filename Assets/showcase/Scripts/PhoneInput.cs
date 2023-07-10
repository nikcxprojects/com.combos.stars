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
        // ������� ��� �������, ����� ����
        string cleanedNumber = new string(System.Text.RegularExpressions.Regex.Replace(input, @"[^\d]", "").ToCharArray());

        // ���������, ��� ����� �������� ����� ����������� ���������� ����
        if (cleanedNumber.Length >= 11)
        {
            // �������� ������� "+" � ��� ������ "7"
            var cleanedNumberFirst = $"+{cleanedNumber.Substring(0, 1)} {cleanedNumber.Substring(1, 3)} ";

            // �������� ��������� ����� ������ ��������
            if (cleanedNumber.Length >= 9)
            {
                //89996394765
                cleanedNumber = cleanedNumberFirst + $"{cleanedNumber.Substring(4, 3)}-{cleanedNumber.Substring(7,2)}-{cleanedNumber.Substring(9)}";
            }

            InputField.text = cleanedNumber;
        }
    }
}
