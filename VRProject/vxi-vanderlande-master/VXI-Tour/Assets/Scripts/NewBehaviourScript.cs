using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;


public class NewBehaviourScript : MonoBehaviour {


	KeywordRecognizer keyWordRecognizer;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	// Use this for initialization
	void Start ()  {
		keywords.Add("go", () =>
			{
				goCalled();

			});
		keyWordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
		keyWordRecognizer.OnPhraseRecognized += KeyWordRecognizedOnPhraseRecognized;
		keyWordRecognizer.Start();
	}

	// Update is called once per frame
	void Update () {

	}

	void KeyWordRecognizedOnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keyAction;
		if(keywords.TryGetValue(args.text, out keyAction))
		{
			keyAction.Invoke();
		}

	}

	void  goCalled()
	{
		Debug.Log("You jyst said go");
	}
}
