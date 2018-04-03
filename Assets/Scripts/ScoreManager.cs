using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    [SerializeField]
    string url;
    public Player player;
    public Score score;

	// Use this for initialization
	void Start () {
        StartCoroutine(Results());
    }

    IEnumerator Results()
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();
        Player player = new Player("Mike");
        Score score = new Score (2000);


        headers.Add("Name", "Score");
        WWW www = new WWW(url, null, headers);
        yield return www;
    }
}

public class Score
{
    public Score(int inScore)
    {
        score = inScore;
    }
    public int score;
}

public class Player{
    public Player(string inName)
    {
        name = inName;
    }
    public string name;
}


