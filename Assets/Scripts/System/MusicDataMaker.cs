using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MusicDataMaker : MonoBehaviour
{
    //public KeyCode KC;
    //public KeyCode save;
    [System.Serializable]
    public class Notes
    {
        public int id;
        public float times;
        public int type;
        public bool hasSpawned;
        public string NotesPosition;
    }

    [System.Serializable]
    public class NotesList
    {
        public float MusicTotalTime;
        public int totalNotes;
        public float beatFallSpeed;
        public Notes[] notes;
    }

    public string FileName;
    public float PassingTime;

    public NotesList myNotesList = new NotesList();

    public int id = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        
        myNotesList.notes = new Notes[350];
        id = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        PassingTime += Time.deltaTime;
    }
    public void OnNotesKey() {
        myNotesList.notes[id].id = id;

        myNotesList.notes[id].times = PassingTime;

        myNotesList.notes[id].type = UnityEngine.Random.Range(1, 5);

        myNotesList.notes[id].hasSpawned = false;

        if (UnityEngine.Random.Range(0, 3) > 1)
        {
            myNotesList.notes[id].NotesPosition = "Left";
        }
        else
        {
            myNotesList.notes[id].NotesPosition = "Right";
        }

        id++;
    }

    public void OnSaveMusicData() {
        Array.Resize(ref myNotesList.notes, id);
        myNotesList.totalNotes = id;
        myNotesList.MusicTotalTime = PassingTime;
        myNotesList.beatFallSpeed = 240;
        string jsondata = JsonUtility.ToJson(myNotesList);
        Debug.Log("music data files saved path is"+@"\MusicData\" + FileName + ".txt");

        using StreamWriter writer = new StreamWriter(Application.dataPath + @"\MusicData\" + FileName+".txt");
        writer.Write(jsondata);
    }
}
