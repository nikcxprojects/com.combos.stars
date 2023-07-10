using UnityEngine;

public class RotateMe : MonoBehaviour
{
    private void Update() => transform.Rotate(25.0f * Time.deltaTime * Vector3.back);
}
