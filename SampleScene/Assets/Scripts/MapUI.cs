using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{
    public static MapUI Instance;

    public GameObject mapPanel;
    public GameObject openMapButton;
    public Button closeButton;

    private bool isOpen = false;
    private bool hasMap = false;

    void Awake()
    {
        Instance = this;
        mapPanel.SetActive(false);

        if (openMapButton != null)
            openMapButton.SetActive(false);

        if (closeButton != null)
            closeButton.onClick.AddListener(CloseMap);
    }

    void Update()
    {
        if (hasMap && Input.GetKeyDown(KeyCode.M))
        {
            if (isOpen)
                CloseMap();
            else
                OpenMap();
        }
    }
    public void UnlockMap()
    {
        hasMap = true;
        if (openMapButton != null)
            openMapButton.SetActive(true);
    }

    public void OpenMap()
    {
        isOpen = true;
        mapPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseMap()
    {
        isOpen = false;
        mapPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}