﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Threading.Tasks;

public class HighScoreTable : MonoBehaviour
{
    [SerializeField]
    public string highscoreFile = "scores.txt";

    

    public struct HighScoreEntry
    {
        public int score;
        public string name;
    }

     public List<HighScoreEntry> allScores = new List<HighScoreEntry>();

    

    [SerializeField]
    Font scoreFont;

    void CreateHighScoreText()
    {
        for (int i = 0; i < 10; ++i)
        {
            GameObject o = new GameObject();
            o.transform.parent = transform;

            Text t = o.AddComponent<Text>();
            t.text = allScores[i].name + "\t\t" + allScores[i].score;
            t.font = scoreFont;
            t.fontSize = 50;

            o.transform.localPosition = new Vector3(0, -(i) * 6, 0);

            o.transform.localRotation = Quaternion.identity;
            o.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            o.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 100);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        LoadHighScoreTable();
        SortHighScoreEntries();
        CreateHighScoreText();


    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void LoadHighScoreTable()
    {
        using (TextReader file = File.OpenText(highscoreFile))
        {
            string text = null;
            while ((text = file.ReadLine()) != null)
            {
                Debug.Log(text);
                string[] splits = text.Split(' ');
                HighScoreEntry entry;
                entry.name = splits[0];
                entry.score = int.Parse(splits[1]);
                allScores.Add(entry);
            }
        }
    }

    public void SortHighScoreEntries()
    {
        allScores.Sort((x, y) => y.score.CompareTo(x.score));

    }

   
    
}

