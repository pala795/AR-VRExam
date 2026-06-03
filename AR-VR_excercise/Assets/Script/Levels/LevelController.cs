using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    //[SerializeField] private GameObject _roomOfFortunePrefab;
    private GameObject _startingRoomPrefab;
    [SerializeField] private List<GameObject> _roomPrefabs = new();

    private bool _hasSpawnedStartingRoom = false;

    private int _currentRoomIndex = 0;
    private GameObject _currentSpawnedRoom;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        SpawnRoom(); 
    }
    
    public void SpawnRoom()
    {
        GameObject prefabToSpawn = null;
            
        prefabToSpawn = _roomPrefabs[_currentRoomIndex];
        //No room to spawn
        if (prefabToSpawn == null) return;

        //Destroy previous room
        if (_startingRoomPrefab != null)
        {
            Debug.Log("Destroying " + _startingRoomPrefab.name);
            Destroy(_startingRoomPrefab);
        }
        else if (_currentSpawnedRoom != null)
        {
            Debug.Log("Destroying " + _currentSpawnedRoom.name);
            Destroy(_currentSpawnedRoom);
        }

        //Spawn the new room
        _currentSpawnedRoom = Instantiate(prefabToSpawn, Vector3.zero, Quaternion.identity);
        _currentRoomIndex++;

        /*if (_currentRoomIndex >= _finalRoomOrder.Count)
        {
            _roomComponent.IsFinalRoom = true;
            Debug.Log("This is the FINAL ROOM.");
        }*/
    }
}