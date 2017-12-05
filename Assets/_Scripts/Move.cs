using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private Turn _turn;
    [SerializeField] private Board _board;
    [SerializeField] private Vector3 _target;
    [SerializeField] private float _step;
    
    [SerializeField] public int currentSpace;
    
    private void Update()
    {
        _target = new Vector3(_board.BoardPlaces[currentSpace].transform.position.x, transform.position.y, _board.BoardPlaces[currentSpace].transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, _target, _step);
    }
}
