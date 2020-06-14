using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{

    [Serializable]
    public struct LeaderboardEntry
    {
        public string name;
        public int score;
    }

    public List<LeaderboardEntry> entries;
    public Text text;

    public float linewidth;
    // Start is called before the first frame update
    void Start()
    {
        // entries = JsonUtility.FromJson<LeaderboardEntry[]>(PlayerPrefs.GetString("leaderboard"));
        int i = 0;
        foreach (LeaderboardEntry entry in entries)
        {
            print(entry.name);
            Text t = Instantiate(text, transform.position + new Vector3(0, i * linewidth, 0), Quaternion.identity);
            t.text = entry.name + ": " + entry.score;
            i++;
        }
        Save();
    }

    void Save()
    {
        print(JsonUtility.ToJson(entries));
        // PlayerPrefs.SetString("leaderboard", JsonUtility.ToJson(entries));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
