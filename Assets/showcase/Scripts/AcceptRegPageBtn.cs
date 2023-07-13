using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AcceptRegPageBtn : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            SwocaseBooter.RegPageAccept = 1;
            SceneManager.LoadScene("showcase");
        });
    }
}
