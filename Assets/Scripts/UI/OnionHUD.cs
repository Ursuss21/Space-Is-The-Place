using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnionHUD : MonoBehaviour
{
    [SerializeField]
    Text onionText = null;

    public static OnionHUD instance { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseOnions()
    {
        onionText.text = Player.instance.GetOnions().ToString();
    }
}
