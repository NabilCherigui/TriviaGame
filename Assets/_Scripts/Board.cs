using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

	[SerializeField] private GameObject[] _boardPlaces;
	[SerializeField] private Material[] _boardMaterials;

	private int _color;

	public GameObject[] BoardPlaces
	{
		get { return _boardPlaces; }
	}
		
	private void Start()
	{
		for (var i = 0; i < _boardPlaces.Length; i++)
		{
			_color++;
			if (_color == _boardMaterials.Length) _color = 0;
			_boardPlaces[i].GetComponent<Renderer>().material = _boardMaterials[_color];
		}
	}
}
