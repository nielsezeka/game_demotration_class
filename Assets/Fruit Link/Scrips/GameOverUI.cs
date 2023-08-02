using UnityEngine;
using System.Collections;

public class GameOverUI : MonoBehaviour {

	bool isHold = false;
	bool select = false;
	string nameObj = "";

	public GameObject[] soundButton = new GameObject[4];
	public GameObject[] menuButton = new GameObject[2];
	public GameObject[] restartButton = new GameObject[2];

	public Sprite[] number = new Sprite[10];
	public SpriteRenderer[] ScoreNumbers = new SpriteRenderer[5];
	public SpriteRenderer[] BestScoreNumbers = new SpriteRenderer[5];

	void Start ()
	{
		GlobalValues.isGameoverUI = true;
		//set score
		showScore (GlobalValues.Score, ScoreNumbers, number);
		showScore (GlobalValues.TargetScore, BestScoreNumbers, number);
	}
	
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			isHold = true;
		}
		if (Input.GetMouseButtonUp (0)) {
			isHold = false;	
			select = false;
			if (checkTouch (Input.mousePosition).name == nameObj)
				addAction (nameObj);
		}
		if (isHold) {
			if (!select) {
				holdeffect (checkTouch (Input.mousePosition).name);
				nameObj = checkTouch (Input.mousePosition).name;
			}
			select = true;
		} else {						
			unSelect ();
		}	
	}
	
	void addAction (string nameobj)
	{
		switch (nameobj) {
		case "menu":
			Application.LoadLevel("welcome");		
			break;
		case "restart":
			Application.LoadLevel("play");		
			break;
		default:
			break;
		}
	}
	
	void holdeffect (string nameobj)
	{
		switch (nameobj) {
		case "menu":
			menuButton [1].SetActive (true);
			break;
		case "restart":
			restartButton [1].SetActive (true);
			break;
		default:
			break;
		}
	}
	
	void unSelect ()
	{
		soundButton [1].SetActive (false);
		soundButton [3].SetActive (false);
		menuButton [1].SetActive (false);
		restartButton [1].SetActive (false);		
	}	
	
	GameObject checkTouch (Vector3 pos)
	{
		Vector3 wp = Camera.main.ScreenToWorldPoint (pos);
		Vector2 touchPos = new Vector2 (wp.x, wp.y);
		GameObject ObjPointer = null;
		if (Physics2D.OverlapPoint (touchPos)) 
			ObjPointer = Physics2D.OverlapPoint (touchPos).gameObject;
		
		return ObjPointer;
		
	}
	void showScore(int score, SpriteRenderer[] renderer, Sprite[] number)
	{
		int chucnghin = 0;
		int nghin_ = 0;
		int tram_ = 0;
		int chuc_ = 0;
		int dv_ = 0;
		int temp_ = 0;
		chucnghin = score / 10000;
		temp_ =score % 10000;
		nghin_ = temp_ / 1000;
		temp_= temp_ % 1000;
		tram_ = temp_ / 100;
		temp_ = temp_ % 100;
		chuc_ = temp_ / 10;
		temp_ = temp_ % 10;
		dv_ = temp_;
		renderer[0].sprite = number[dv_];
		renderer[1].sprite = number[chuc_];
		renderer[2].sprite = number[tram_];
		renderer[3].sprite = number[nghin_];
		renderer[4].sprite = number[chucnghin];
		
		if (score >= 10000)
			renderer [4].enabled = true;
		else {
			renderer [4].enabled = false;
		}
		
		if (score >= 1000)
			renderer [3].enabled = true;
		else {
			renderer [3].enabled = false;
		}
		if (score >= 100)
			renderer [2].enabled = true;
		else
			renderer [2].enabled = false;
		if (score >= 10)
			renderer [1].enabled = true;
		else
			renderer [1].enabled = false;
	}
}
