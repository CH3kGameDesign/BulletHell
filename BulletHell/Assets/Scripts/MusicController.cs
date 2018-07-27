using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public int currentSong;
    private int pastSong;

    private AudioSource[] songList;

	// Use this for initialization
	void Start () {
        songList = GetComponents<AudioSource>();
		currentSong = -1;
        NewSong();
    }
	
	// Update is called once per frame
	void Update () {
        if (!songList[currentSong].isPlaying)
            NewSong();
	}

    public void NewSong ()
    {
        for (int i = 0; i < songList.Length; i++)
        {
            songList[i].Stop();
        }

        pastSong = currentSong;
        while (currentSong == pastSong)
        {
            currentSong = Random.Range(0, songList.Length);
        }
        
        songList[currentSong].Play();
    }
}
