using UnityEngine;
public class ColorChoose : MonoBehaviour 
{	
	// Create GUI Buttons. 
	void OnGUI()
	{
		GUIStyle MyButtonStyle = new GUIStyle(GUI.skin.button);
		MyButtonStyle.fontSize = 60;
		
		Font myFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
		MyButtonStyle.font = myFont;
		
		MyButtonStyle.normal.textColor = Color.white;
		MyButtonStyle.hover.textColor = Color.gray;
		GUI.backgroundColor = Color.cyan;

		if (GUI.Button(new Rect(750, 400, 300, 200), "Blue",MyButtonStyle))
			GetComponent<Logic>().SpawnPeg(0);
		if(GUI.Button(new Rect(750,600,300,200), "Green", MyButtonStyle))
			GetComponent<Logic>().SpawnPeg(1);
		if(GUI.Button(new Rect(750, 800,300,200), "Orange", MyButtonStyle))
			GetComponent<Logic>().SpawnPeg(2);
		if(GUI.Button(new Rect(750, 1000,300,200), "Red", MyButtonStyle))
			GetComponent<Logic>().SpawnPeg(3);
		if(GUI.Button(new Rect(750, 1200,300,200), "Pink", MyButtonStyle))
			GetComponent<Logic>().SpawnPeg(4);
		if(GUI.Button(new Rect(750, 1400,300,200), "Yellow", MyButtonStyle))
			GetComponent<Logic>().SpawnPeg(5);
	}
}
