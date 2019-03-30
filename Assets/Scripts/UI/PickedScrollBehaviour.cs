using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickedScrollBehaviour : MonoBehaviour
{
    [SerializeField]
    private Text TextBox, Title;

    public void setTextInScroll(string box, string title)
    {
        TextBox.text = box;
        Title.text = title;
    }

    public void DisableScroll()
    {
        this.gameObject.SetActive(false);
    }

   
}
