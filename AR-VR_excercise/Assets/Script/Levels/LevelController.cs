using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    //[SerializeField] private GameObject _roomOfFortunePrefab;
    [SerializeField] private List<GameObject> _roomPrefabs = new();
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

        if (_currentSpawnedRoom != null)
        {
            Debug.Log("Destroying " + _currentSpawnedRoom.name);
            Destroy(_currentSpawnedRoom);
        }

        //Spawn the new room
        _currentSpawnedRoom = Instantiate(prefabToSpawn, Vector3.zero, Quaternion.identity);
        _currentRoomIndex++;
    }
}