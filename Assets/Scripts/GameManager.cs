using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	
	public InputField input;
	public Text showWord;
	public StringBuilder displayWord = new StringBuilder();
	public List<string> wordList = new List<string> { "CZEKOLADA", "ALKOHOL", "NARKOTYKI", "REZYSTOR", "PIWO", "MONITOR", "KOWBOJ", "DRZEWO", "GRZYB",
	"PISTOLET", "DRUKARKA", "PRZEDSZKOLE", "ZASADA", "GRECJA", "WINO", "CHLEB", "BAZYLIA" ,
	"KOT", "PIES", "AUTOBUS"};

    public string word, guess, wordToShow;
    public bool win;
	public int test, hangman;
    public Image image;
	public Sprite[] sprite = new Sprite[13];
	public Text przegrankoText;
	public Text wygrankoText;
    public Text info1, info2, info3;


	void Start()
	{
        
        word = PickWord().ToUpper();
		BuildWord(word);
		drawHangman(0);
	}

	public void drawHangman(int hangman)
	{
        if ((hangman >= 0) && (hangman <= 12))
		image.sprite = sprite[hangman];
	}
	public string PickWord()
	{
		System.Random randNum = new System.Random();
		int wordNumber = randNum.Next(1, wordList.Count);
		return wordList[wordNumber];
	}

	public void BuildWord(string word)
	{
		displayWord.Remove(0, displayWord.Length);
		for(int i = 0; i <word.Length;i++)
		{
			displayWord.Append("-");
		}
		showWord.text=displayWord.ToString();
		
	}

	public void setget()
	{
		test = 1;
		guess = input.text;
		int check = 0;
		for(int i=0;i<word.Length;i++)
		{
			if (guess == word[i].ToString())
			{
				displayWord[i] = guess[0];
				check++;
			}
		}
		if(displayWord.ToString()==word)
		{
            
			Debug.Log("Wygranko");
            showWord.text = word;
            info3.text = "Nacisnij ENTER";
            int buf = hangman;
            if (Input.GetKeyDown("return"))
                hangman++;
            if (hangman>buf)
                Application.LoadLevel("Win Screen");

        }

		if(check==0)
		{
			hangman++;
			drawHangman(hangman);
		}
		showWord.text = displayWord.ToString();
		if(hangman==12)
		{
			showWord.text = word;
            info3.text = "Nacisnij ENTER";

        }
        if(hangman==13)
        {
            Application.LoadLevel("Lose Screen");
        }

	}
    void Update()
    {
        input.Select();
        input.ActivateInputField();

        if (Input.GetKeyDown("return"))
        {
            setget();
            input.text = "";
        }
        wordToShow = displayWord.ToString();

        if (Input.GetKeyDown("escape"))
        {
            Application.LoadLevel("Start Menu");
        }
        if (test != 0)
        {
            info1.text = "";
            info2.text = "";
        }

        
	}

	
}
