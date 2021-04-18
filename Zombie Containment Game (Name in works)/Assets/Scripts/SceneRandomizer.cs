using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRandomizer : MonoBehaviour
{
    public List<int> listOfScenes = new List<int>();
    public int selectedScene;
    public int listSize;

    void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            listOfScenes.Add(i);
        }

        listSize = listOfScenes.Count;
        selectedScene = listOfScenes[Random.Range(0, listSize)];
    }
    
    void OnTriggerEnter(Collider other)
    {


        SceneManager.LoadScene(selectedScene);
        listOfScenes.Remove(selectedScene);
        
        //Debug.Log(selectedScene);
        //Debug.Log(listOfScenes.);
    }
}
