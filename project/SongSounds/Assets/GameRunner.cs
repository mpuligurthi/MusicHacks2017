using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class GameRunner : MonoBehaviour {
    int score = 0;
    double time = 90;
    public GameObject SongString;
    List<string> songs = new List<string>();

    void Start()
    {
        ReadSongs();
        NewRandomSong();
    }
    // Update is called once per frame
    void Update () {
        time -= Time.deltaTime;
       
	}

    public void Right()
    {
        score++;
        NewRandomSong();
    }

    public void Pass()
    {
        NewRandomSong();
    }

    void NewRandomSong()
    {

        SongString.GetComponent<Text>().text = songs[Random.Range(0, songs.Count)];
    }



    void ReadSongs()
    {
        TextAsset asset = Resources.Load("Songs") as TextAsset;

        string[] linesFromfile = asset.text.Split('\n');
        foreach (string line in linesFromfile)
        {
            songs.Add(line);
        }


/*
        string path = "Assets/Songs.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string line;
        while ((line = reader.ReadLine()) != null)
            songs.Add(line);
        reader.Close();*/
    }
}
