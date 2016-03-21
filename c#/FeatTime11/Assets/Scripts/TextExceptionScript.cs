using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace RoleGame
{
public class TextExceptionScript : MonoBehaviour
{
		private static Text text;
		private float Timer=5f;
	// Use this for initialization
	void Start ()
		{
			text = GetComponent<Text> ();
		}
	public static void TextWrite( string s)
		{
			Text TextException = (GameObject.FindWithTag ("Exception")).GetComponent<Text>();
			TextException.text = s;
		}
	// Update is called once per frame
	void Update () 
		{
			if (text.text != "")
				Timer -= Time.deltaTime;
			if (Timer <= 0.0f) 
			{
				Timer = 5f;
				text.text="";
			}

		}
}
}
