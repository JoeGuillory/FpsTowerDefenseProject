using Steamworks;
using UnityEngine;

public class SteamTestScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(SteamManager.Initialized)
        {
            var lobby = SteamFriends.GetPersonaName();
            Debug.Log(lobby);
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
