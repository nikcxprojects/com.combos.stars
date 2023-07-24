using UnityEngine;

public class Viewer : MonoBehaviour
{
    private static Viewer Instance
    {
        get => FindObjectOfType<Viewer>();
    }

    private UniWebView View { get; set; }

    private void Awake()
    {
        CacheComponents();
    }

    public static void Init(string url)
    {
        var prefab = Resources.Load<GameObject>("View");
        Instantiate(prefab);

        var gameCanvas = GameObject.Find("game canvas").transform.GetChild(0).gameObject;
        gameCanvas.SetActive(false);

        Instance.View.Load(url);

        Screen.fullScreen = false;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    private void CacheComponents()
    {
        View = gameObject.AddComponent<UniWebView>();

        var rect = GameObject.Find("rect").GetComponent<RectTransform>();
        View.ReferenceRectTransform = rect;

        var safeArea = Screen.safeArea;
        var anchorMin = safeArea.position;
        var anchorMax = anchorMin + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        View.ReferenceRectTransform.anchorMin = anchorMin;
        View.ReferenceRectTransform.anchorMax = anchorMax;

        View.SetShowSpinnerWhileLoading(false);
        View.BackgroundColor = Color.black;

        View.OnOrientationChanged += (v, o) =>
        {
            Screen.fullScreen = o == ScreenOrientation.Landscape;

            var safeArea = Screen.safeArea;
            var anchorMin = safeArea.position;
            var anchorMax = anchorMin + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            v.ReferenceRectTransform.anchorMin = anchorMin;
            v.ReferenceRectTransform.anchorMax = anchorMax;

            View.UpdateFrame();
        };

        View.OnPageStarted += (browser, url) =>
        {
            var safeArea = Screen.safeArea;
            var anchorMin = safeArea.position;
            var anchorMax = anchorMin + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            View.ReferenceRectTransform.anchorMin = anchorMin;
            View.ReferenceRectTransform.anchorMax = anchorMax;

            View.Show();
            View.UpdateFrame();
        };

        View.OnShouldClose += (v) =>
        {
            var gameCanvas = GameObject.Find("game canvas").transform.GetChild(0).gameObject;
            gameCanvas.SetActive(true);

            View = null;
            Destroy(gameObject);

            return true;
        };
    }
}
