using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{

    static MusicPlayer musicplayer = null;

    void Awake()
    {

        if (musicplayer != null)
        {
            Destroy(gameObject);
            print("Duplicate Music Player self destructing");
        }
        else
        {
            musicplayer = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
