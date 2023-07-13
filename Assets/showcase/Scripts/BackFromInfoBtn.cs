using UnityEngine;
using UnityEngine.UI;

public class BackFromInfoBtn : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(transform.parent.gameObject);
        });
    }
}
