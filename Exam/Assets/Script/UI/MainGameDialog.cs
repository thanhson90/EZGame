using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameDialog : MonoBehaviour
{

    [SerializeField] private List<Image> keyImages;
    public void OnShow()
    {
        GameLogic.Instance.OnKeyChangedCallback += refreshImageIcons;
    }

    public void OnHide()
    {
        GameLogic.Instance.OnKeyChangedCallback -= refreshImageIcons;
    }

    private void refreshImageIcons(int keyCounts)
    {
        for (int i = 0; i < keyImages.Count; i++)
        {
            keyImages[i].gameObject.SetActive(i<keyCounts);
        }

    }
}
