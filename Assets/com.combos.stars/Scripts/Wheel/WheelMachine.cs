using System;
using UnityEngine;
using UnityEngine.UI;

public class WheelMachine : MonoBehaviour
{
    public static WheelMachine Instance { get => FindObjectOfType<WheelMachine>(); }

    [SerializeField] Button pullBtn;
    public AnimationCurve speedCurve;
    public static Action<float> OnHandlePulled { get; set; }
    public static Func<float, int> OnWheelStopped { get; set; }

    public static float[] angles = new float[] { 344.481f, 315.046f, 285.25f, 254.266f, 225.494f, 195.077f, 165.446f, 135.007f, 104.726f, 75.062f, 45.399f, 16.017f };
    public static int[] prizes = new int[] { 50, 20, 10, 100, 50, 20, 10, 100, 50, 20, 10, 100 };

    private void Awake()
    {
        pullBtn.onClick.AddListener(() =>
        {
            PullHandle();
        });

        OnWheelStopped += (angle) =>
        {
            pullBtn.interactable = true;
            
            int index = Array.IndexOf(angles, angle);
            int prize = prizes[index];

            return prize;
        };
    }

    public void PullHandle()
    {
        OnHandlePulled?.Invoke(angles[UnityEngine.Random.Range(0, angles.Length)]);
        pullBtn.interactable = false;
    }
}
