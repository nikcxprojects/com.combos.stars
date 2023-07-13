using UnityEngine;
using UnityEngine.SceneManagement;

public static class SwocaseBooter
{
    public static int RegPageAccept
    {
        get => PlayerPrefs.GetInt("RegPageAccept", 0);
        set => PlayerPrefs.SetInt("RegPageAccept", value);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    public static void Execute()
    {
        SceneManager.LoadScene(RegPageAccept > 0 ? "showcase" : "regpage");
    }
}
