using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDataReader : MonoBehaviour
{
    public TextAsset textJSON;
    
    [System.Serializable]
    public class Notes
    {
        public int id;
        public float times;
        public int type;
        public bool hasSpawned;
    }

    [System.Serializable]
    public class NotesList
    {
        public float MusicTotalTime;
        public int totalNotes;
        public int beatFallSpeed;
        public Notes[] notes;
    }
    
    public NotesList myNotesList = new NotesList();
    // Start is called before the first frame update
    void Start()
    {
        myNotesList = JsonUtility.FromJson<NotesList>(textJSON.text);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
