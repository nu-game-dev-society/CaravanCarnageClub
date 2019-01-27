using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

[System.Serializable]
public class Score
{
    public string name;
    public int score;
}

[System.Serializable]
public class ScoreData
{
    public Score[] scores;
}

public static class ScoreWeb
{
    public static void Send(string name, int score)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://81.174.149.122/ggj/submit.php?name=" + name + "&score=" + score);
        request.GetResponse();
    }

    public static Score[] Get()
    {
        string html = string.Empty;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://81.174.149.122/ggj/get.php");
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }
        
        return JsonUtility.FromJson<ScoreData>(html).scores;
    }
}
