using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{

    [SerializeField] private Database _database;
    [SerializeField] private Text _question;
    [SerializeField] private Text _answer1;
    [SerializeField] private Text _answer2;
    [SerializeField] private Text _answer3;
    [SerializeField] private Text _answer4;

    private void Update()
    {
        _question.text = _database.Question;
        if (_database.Type == "boolean")
        {
            _answer1.text = _database.Answers["Correct"];
            _answer2.text = _database.Answers["Incorrect0"];
            _answer3.text = "";
            _answer4.text = "";
        }
        else if (_database.Type == "multiple")
        {
            _answer1.text = _database.Answers["Correct"];
            _answer2.text = _database.Answers["Incorrect0"];
            _answer3.text = _database.Answers["Incorrect1"];
            _answer4.text = _database.Answers["Incorrect2"];   
        }
    }
}
