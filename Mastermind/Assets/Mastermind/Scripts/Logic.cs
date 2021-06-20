using UnityEngine;
public class Logic : MonoBehaviour 
{
	public GameObject peg;
	public GameObject peg_small;
	public GameObject txt;
	private int[] result = new int[4];
	private int[] rowpegs = new int[4];
	private int rownumber, pegnumber = 0;
	private int xstart = 18;
	private int zstart = -8;
	private bool won, lose = false;
	private int[] tempresult;
	int score = 0;

	// Initialization.
	void Start ()
	{
		for(int i =0; i<4; i++)
		{
			result[i] = (int)Random.Range(0, 6);
			GameObject obj = Instantiate(peg, new Vector3(-24, 2, zstart + (4*i)), peg.transform.rotation) as GameObject;
			obj.GetComponent<Peg>().pegcolornr = result[i];
		}
	}

	// Called when user clicks on a color button - ColorChoose script.
	// Colornr will be used to set the color in Peg script.
	public void SpawnPeg(int colornr)
	{
		GameObject obj = Instantiate(peg, new Vector3(xstart - (4*rownumber), 2, zstart + (4*pegnumber)), peg.transform.rotation) as GameObject;
		obj.GetComponent<Peg>().pegcolornr = colornr;
		rowpegs[pegnumber] = colornr;
		
		if(pegnumber < 3)
			pegnumber++;
		else{
			int[] mp = CheckResult();
			if(mp[0] == 4)
				Win();
			
			pegnumber = 0;
			if(rownumber < 9)
				rownumber++;
			else
				Lose();
		}
	}
	
	public void SpawnMiniPegs(int[] minipegs)
	{
		int[] mp = new int[minipegs[0]+minipegs[1]];
		for(int i = 0; i<minipegs[0]; i++)
			mp[i] = 0;
		for(int j = minipegs[0]; j<minipegs[0]+minipegs[1]; j++)
			mp[j] = 1;
		
		for(int m = 0; m < mp.Length; m++)
		{
			GameObject obj = Instantiate(peg_small, new Vector3(xstart - (4*rownumber) - (2*(m/2)-1), 2, 7 + (2*(m%2))), peg_small.transform.rotation) as GameObject;
			obj.GetComponent<Peg>().pegcolornr = mp[m];
		}
	}
	
	int[] CheckResult()
	{
		tempresult = new int[4];
		result.CopyTo(tempresult, 0);
		int[] minipegs = new int[2];
		minipegs[0] = minipegs[1] = 0;

		// Check if color and Position matches(Bulls).
		for (int i =0; i < 4; i++)
			if(tempresult[i] == rowpegs[i])
			{
				rowpegs[i] = -1; 
				tempresult[i] = -2;
				minipegs[0]++;
				score++;
				txt.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
			}

		// Check if color is in result(Cows).
		if (minipegs[0] < 4)
			for(int j=0; j<4; j++)
				if(rowpegs[j] >= 0)
					if(CheckColor(rowpegs[j]))
					{
						rowpegs[j] = -1; 
						minipegs[1]++;
					}
		
		SpawnMiniPegs(minipegs);
		return minipegs;
	}
	bool CheckColor(int p)
	{
		for(int i=0; i<4; i++)
			if(p == tempresult[i])
			{
				tempresult[i] = -2; return true;
			}
			
		return false;
	}
	
	// Called when all pegs are matching with result.
	void Win()
	{
		GetComponent<ColorChoose>().enabled= false;
		GetComponent<Animation>().Play();
		won = true;
	}

	// Called when pegs are not matching with result.
	void Lose()
	{
		GetComponent<ColorChoose>().enabled= false;
		GetComponent<Animation>().Play();
		lose = true;
	}

    [System.Obsolete]
    void OnGUI(){

		GUIStyle MyButtonStyle = new GUIStyle(GUI.skin.button);
		MyButtonStyle.fontSize = 60;
		
		Font myFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
		MyButtonStyle.font = myFont;
		
		MyButtonStyle.normal.textColor = Color.white;
		MyButtonStyle.hover.textColor = Color.gray;
		GUI.backgroundColor = Color.cyan;

		if (won){
			if(GUI.Button(new Rect(Screen.width/2-350, Screen.height/2, 700, 150), "You won click to restart", MyButtonStyle))
				Application.LoadLevel(Application.loadedLevelName);
		}
		else if(lose){
			if(GUI.Button(new Rect(Screen.width/2-350, Screen.height/2, 700, 150), "You lost click to restart", MyButtonStyle))
				Application.LoadLevel(Application.loadedLevelName);
		}
	}
}
