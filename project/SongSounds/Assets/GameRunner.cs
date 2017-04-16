using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameRunner : MonoBehaviour {
    int score = 0;
    double time = 120;
    public GameObject SongString;
    public GameObject TimeString;
    public GameObject ScoreString;
    public GameObject GameOver;
    List<string> songs = new List<string>();

    void Start()
    {
        Time.timeScale = 1;
        ReadSongs();
        NewRandomSong();
    }
    // Update is called once per frame
    void Update () {
        TimeString.GetComponent<Text>().text = "" + (int)(time -= Time.deltaTime);

        if (time <= 0)
        {
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }
}

    public void Right()
    {
        if (time > 0)
        {
            ScoreString.GetComponent<Text>().text = "" + ++score;
            NewRandomSong();
        }
        else
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Pass()
    {
        NewRandomSong();
        time -= 10;
    }

    void NewRandomSong()
    {
        if (time > 0)
        {
            Time.timeScale = 1;
            SongString.GetComponent<Text>().text = songs[Random.Range(0, songs.Count)];
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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
