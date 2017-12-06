using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    [SerializeField] private Turn _turn;
    [SerializeField] private string url;
    [SerializeField] private string _type;
    [SerializeField] private string _question;
    [SerializeField] private string _difficulty;
    
    private Dictionary<string, string> _answers = new Dictionary<string, string>();
    private DBresult _result;
    private bool _startCou;

    public string Type {get { return _type; }}
    public string Question {get { return _question; }}
    public Dictionary<string,string> Answers {get { return _answers; }}
    
    IEnumerator Start()
    {
        var www = new WWW(url);
        yield return www;
        
        _result = JsonUtility.FromJson<DBresult>(www.text);
    }

    private void Update()
    {
        print(_turn.Difficulty);
        GetData();
    }

    [Serializable]
    public class DBresult
    {
        public int response_code = 0;
        public TriviaQuestion[] results;
    }

    [Serializable]
    public class TriviaQuestion
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public string[] incorrect_answers;
    }

    public void RestartCoroutine()
    {
        StopCoroutine(Start());
        url = "https://opentdb.com/api.php?amount=1&difficulty=" + _turn.Difficulty;
        StartCoroutine(Start());
    }

    private void GetData()
    {
        if (!String.IsNullOrEmpty(_turn.Difficulty) && _turn.Answered == false)
        {
            print("it works");
            
            if (_answers.Count > 0)
            {
                _answers.Clear();   
            }
            
            _type = _result.results[0].type.Replace("&#039;","'").Replace("&quot;", @"""").Replace("&eacute;","é").Replace("&amp","&").Replace("&Aring;","Å").Replace("&uuml;","ü");
            _question = _result.results[0].question.Replace("&#039;","'").Replace("&quot;", @"""").Replace("&eacute;","é").Replace("&amp","&").Replace("&Aring;","Å").Replace("&uuml;","ü");
            _difficulty = _result.results[0].difficulty.Replace("&#039;","'").Replace("&quot;", @"""").Replace("&eacute;","é").Replace("&amp","&").Replace("&Aring;","Å").Replace("&uuml;","ü");
            _answers.Add("Correct" , _result.results[0].correct_answer.Replace("&#039;","'").Replace("&quot;", @"""").Replace("&eacute;","é").Replace("&amp","&").Replace("&uuml;","ü"));
            
            for (var i = 0; i < _result.results[0].incorrect_answers.Length; i++)
            {
                _answers.Add("Incorrect" + i, _result.results[0].incorrect_answers[i].Replace("&#039;","'").Replace("&quot;", @"""").Replace("&eacute;","é").Replace("&amp","&").Replace("&uuml;","ü"));
            }   
        }
    }
}
