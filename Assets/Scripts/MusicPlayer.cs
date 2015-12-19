using UnityEngine;
using System.Collections;

public sealed class MusicPlayer : MonoBehaviour {

    //Uses singleton pattern referenced here https://gist.github.com/Ashwinning/5a1d5858959af0396b04
    private static MusicPlayer _instance;
    
    public static MusicPlayer instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MusicPlayer>();
                DontDestroyOnLoad(_instance);
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != instance)
            {
                Destroy(this.gameObject);
            }
        }
    }

	// Use this for initialization
	void Start () {         
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
