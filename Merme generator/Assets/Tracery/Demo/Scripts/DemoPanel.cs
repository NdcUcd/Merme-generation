using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityTracery;
using TMPro;

[ExecuteInEditMode]
public class DemoPanel : MonoBehaviour {
	public TextAsset GrammarFile;
	public InputField GrammarInput;
	public InputField TokenInput;
	public TextMeshProUGUI TextOutput;

	public TraceryGrammar Grammar;

	private void Start() {
		Debug.Log("GrammarFile text: " + GrammarFile.text);
		GrammarInput.text = GrammarFile.text;
		UpdateGrammar();
	}

	public void UpdateGrammar() {
		Debug.Log(GrammarInput.text);
		Grammar = new TraceryGrammar(GrammarInput.text);
	}

	public void GenerateOutput() {
		var output = Grammar.Parse(TokenInput.text);
		TextOutput.text = output;
	}
}
