using UnityEngine;
using TMPro; // remove this line and use UnityEngine.UI + Text if not using TMP

public class InteractionPromptUI : MonoBehaviour
{
    public static InteractionPromptUI Instance;

    public GameObject promptRoot;   // the InteractionPrompt GameObject
    public TMP_Text promptText;     // or public Text promptText; if using legacy UI

    void Awake()
    {
        Instance = this;
        Hide();
    }

    public void Show(string message)
    {
        promptRoot.SetActive(true);
        promptText.text = message;
    }

    public void Hide()
    {
        promptRoot.SetActive(false);
    }
}
