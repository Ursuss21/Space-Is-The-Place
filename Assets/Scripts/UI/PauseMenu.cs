using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    Canvas pauseMenuCanvas;
    bool isMenuEnabled = false;

    [SerializeField]
    private GameObject loadingScreen = null;
    [SerializeField]
    private Slider slider = null;

    public static PauseMenu instance { get; set; }

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
        pauseMenuCanvas = gameObject.GetComponent<Canvas>();
        pauseMenuCanvas.enabled = false;
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isMenuEnabled)
            {
                SetMenuVisibilty(false);
            }
            else
            {
                SetMenuVisibilty(true);
            }
        }
        if (isMenuEnabled)
        {
            Cursor.visible = true;
        }
    }

    private void SetMenuVisibilty(bool status)
    {
        pauseMenuCanvas.enabled = status;
        isMenuEnabled = status;
    }

    public void Continue()
    {
        SetMenuVisibilty(false);
    }

    public void Restart()
    {
        StartCoroutine(LoadAsync(SceneManager.GetActiveScene().name));
    }

    public void ExitToMenu()
    {
        StartCoroutine(LoadAsync("MainMenuScene"));
    }

    public void Quit()
    {
        Application.Quit();
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
