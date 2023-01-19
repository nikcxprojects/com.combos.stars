using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject _last = null;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject game1;
    [SerializeField] GameObject game2;
    [SerializeField] GameObject settings;

    [Space(10)]
    [SerializeField] GameObject mark;
    [SerializeField] AudioSource loop;

    [Space(10)]
    [SerializeField] GameObject backBtnGo;

    public void OpenGame(int id)
    {
        menu.SetActive(false);
        if(id == 0)
        {
            _last = game1;
        }
        else if(id == 1)
        {
            _last = game2;
        }

        _last.SetActive(true);
        backBtnGo.SetActive(true);
    }

    public void OpenSettings(bool IsOpen)
    {
        settings.SetActive(IsOpen);
    }

    public void Back()
    {
        if(_last)
        {
            _last.SetActive(false);
        }

        menu.SetActive(true);
        backBtnGo.SetActive(false);
    }

    public void SetOption(Transform option)
    {
        mark.transform.position = option.position;

        if(string.Equals(option.name, "all on"))
        {
            loop.mute = false;
            AudioListener.pause = false;
        }
        else if (string.Equals(option.name, "mute"))
        {
            AudioListener.pause = true;
        }
        else if (string.Equals(option.name, "music only"))
        {
            loop.mute = false;
            AudioListener.pause = false;
        }
    }

    public void BackStatus(bool enable)
    {
        backBtnGo.GetComponent<Button>().interactable = enable;
    }
}