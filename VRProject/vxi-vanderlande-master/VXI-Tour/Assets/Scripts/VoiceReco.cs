using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceReco : MonoBehaviour {
    [SerializeField]
    private string[] m_keyWords;

    private KeywordRecognizer m_Recognizer;
	// Use this for initialization
	void Start () {
        m_keyWords = new string[2];
        m_keyWords[0] = "go";
        m_Recognizer = new KeywordRecognizer(m_keyWords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if (args.text == m_keyWords[0])
        {
            Debug.Log("You said Ruben is lame");
        }
    }
}
