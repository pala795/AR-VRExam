using System;
using System.Collections;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private bool open = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && open)
        {
            StartCoroutine(RoomTransitionCoroutine());
        }
    }

    public bool SetOpen(bool value)
    {
        open = value;
        return open;
    }
    
    
    private IEnumerator RoomTransitionCoroutine( )
    {
        //1 - Fade to Black
        FadeScreen.Instance.FadeIn();
        
        yield return new WaitForSeconds(2f);
        
        //2 - Spawn the next room
        LevelController spawner = LevelController.Instance;

        spawner.SpawnRoom();
       
        //6 - Fade back to gameplay
        FadeScreen.Instance.FadeOut();
        yield return null;
    }
}
