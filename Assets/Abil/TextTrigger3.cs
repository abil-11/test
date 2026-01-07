using UnityEngine;
using TMPro; // Important: This allows the script to see TextMeshPro

public class TextTrigger3 : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("Drag your TextMeshPro component here")]
    public TextMeshProUGUI messageText;

    [Header("Settings")]
    [TextArea(3, 10)]
    public string customMessage = "Hello! This is my new message.";

    
    public void OnButtonPress()
    {
       
        if (messageText == null)
        {
            Debug.LogError("TextTrigger Error: You haven't assigned a TextMeshPro object in the Inspector!");
            return;
        }

        
        messageText.text = customMessage;

        
        messageText.gameObject.SetActive(true);

       
        Debug.Log("Button clicked! Message updated to: " + customMessage);
    }
}