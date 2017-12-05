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
	
	public string Difficulty
	{
		get { return _difficulty; }
	}

	private void Start()
	{
		_players = FindObjectsOfType(typeof(Move)) as Move[];
		_turn = _players[_player];
	}

	private void Update()
	{
		if (_answered)
		{
			_addSpace = true;
			_database.RestartCoroutine();
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
