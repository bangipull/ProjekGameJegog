using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    private List<GameObject> notesInTrigger = new List<GameObject>();
    GameObject GameManager;

    private void Start()
    {
        GameManager = GameObject.Find("GameManager");
        if (GameManager == null)
        {
            Debug.LogError("GameManager tidak ditemukan!");
        }
    }

    void Update()
    {
        // Deteksi sentuhan pada layar
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                // Cek apakah sentuhan terjadi pada objek bambu
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        if (notesInTrigger.Count > 0) // Cek apakah ada note di dalam trigger
                        {
                            DestroyNotesInTrigger();
                            GameManager.GetComponent<GameManager>().AddStreak();
                            AddScore();
                        }
                        else
                        {
                            GameManager.GetComponent<GameManager>().ResetStreak();
                        }
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WinNote");
        GameManager.GetComponent<GameManager>().Win();

        if (other.CompareTag("Note"))
        {
            notesInTrigger.Add(other.gameObject);
            HighlightNoteTile(other.gameObject, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            notesInTrigger.Remove(other.gameObject);
            HighlightNoteTile(other.gameObject, false);
            if (notesInTrigger.Count == 0) // Reset streak if no notes are in the trigger
            {
                GameManager.GetComponent<GameManager>().ResetStreak();
            }
        }
    }

    void AddScore()
    {
        if (GameManager != null)
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + GameManager.GetComponent<GameManager>().GetScore());
        }
    }

    void DestroyNotesInTrigger()
    {
        foreach (GameObject note in notesInTrigger)
        {
            Destroy(note);
        }
        notesInTrigger.Clear();
    }

    void HighlightNoteTile(GameObject note, bool highlight)
    {
        Renderer renderer = note.GetComponent<Renderer>();
        if (renderer != null)
        {
            if (highlight)
            {
                renderer.material.color = Color.red;
            }
            else
            {
                renderer.material.color = Color.white;
            }
        }
    }
}
