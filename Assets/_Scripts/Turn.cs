using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{

	[SerializeField] private Move[] _players;
	[SerializeField] private Move _turn;
	[SerializeField] private Database _database;
	[SerializeField] private int _player;
	[SerializeField] private bool _answered;
	[SerializeField] private bool _addSpace;
	[SerializeField] private int _moveSpaces;
	[SerializeField] private string _difficulty;
	[SerializeField] private bool _difficultySelected;
	
	public bool Answered{ get { return _answered; }}
	public string Difficulty{ get { return _difficulty; }}
	
	private void Start()
	{
		_players = FindObjectsOfType(typeof(Move)) as Move[];
		_turn = _players[_player];
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1) && _difficultySelected == false)
		{
			_difficulty = "easy";
			_database.RestartCoroutine();
			_difficultySelected = true;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2) && _difficultySelected == false)
		{
			_difficulty = "medium";
			_database.RestartCoroutine();
			_difficultySelected = true;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3) && _difficultySelected == false)
		{
			_difficulty = "hard";
			_database.RestartCoroutine();
			_difficultySelected = true;
		}
		
		if (_answered)
		{
			_addSpace = true;
		}
		
		if (_addSpace)
		{
			_players[_player].currentSpace += _moveSpaces;
			_addSpace = false;
			_answered = false;
			_player++;
			if (_player == _players.Length) _player = 0;
		}
	}
}
