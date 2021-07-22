using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    Canvas endScreenCanvas;

    [SerializeField]
    private GameObject loadingScreen = null;
    [SerializeField]
    private Slider slider = null;

    public static EndScreen instance { get; set; }

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

    void Start()
    {
        endScreenCanvas = gameObject.GetComponent<Canvas>();
        endScreenCanvas.enabled = false;
    }

    public void Restart()
    {
        StartCoroutine(LoadAsync(SceneManager.GetActiveScene().name));
    }

    public void ExitToMenu()
    {
        StartCoroutine(LoadAsync("MainMenuScene"));
    }

    public void EnableEndScreen()
    {
        endScreenCanvas.enabled = true;
    }

    IEnumerator LoadAsync(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
