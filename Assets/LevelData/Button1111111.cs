using UnityEngine;
using UnityEngine.UI;

public class Button1111111 : MonoBehaviour
{

    Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
    }

    public void OneClick()
    {
        btn.interactable = false;
    }
}