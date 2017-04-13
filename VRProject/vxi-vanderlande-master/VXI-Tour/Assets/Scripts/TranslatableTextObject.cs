using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SmartLocalization;

/// <summary>
/// This class can be attached to Text objects and will
/// translated the text vaue based on the language in runtime
/// </summary>
public class TranslatableTextObject : MonoBehaviour {

    public string defaultText;

    void Start()
    {
        //Store the original text so changing the language 
        // on runtime will work mulriple times
        defaultText = GetComponent<Text>().text;
    }

	void OnGUI()
    {
        string translatedText = LanguageManager.Instance.GetTextValue(defaultText);
        GetComponent<Text>().text = translatedText != null && translatedText != "" ? translatedText : defaultText;
    }
}
