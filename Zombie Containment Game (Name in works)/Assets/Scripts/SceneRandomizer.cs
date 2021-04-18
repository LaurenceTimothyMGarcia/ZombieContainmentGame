using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRandomizer : MonoBehaviour
{
    static public List<int> listOfScenes = new List<int>();
    public int selectedScene;
    public int arrayNumber;
    public int listSize;
    int currentScene;

    string result;

    public ListOfRooms roomList;

    /*void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            listOfScenes.Add(i);
        }        
    }*/
    
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Starting Size of ArrayList " + listOfScenes.Count);
        if(listOfScenes.Count == 1)
        {
            SceneManager.LoadScene(6);
            return;
        }

        if(listOfScenes.Count == 0)
        {
            ListOfRooms.setArray();
            Debug.Log("Build Index: " + SceneManager.GetActiveScene().buildIndex);
        }
        listOfScenes = ListOfRooms.GetArray();
        //Debug.Log("moveing to next Room");

        listSize = listOfScenes.Count;
        arrayNumber = Random.Range(0, listSize);
        selectedScene = listOfScenes[arrayNumber];

        Debug.Log("This is the scene that was loaded " + selectedScene);
        SceneManager.LoadScene(selectedScene);
        
        Debug.Log("Removed Array: " + arrayNumber);
        Debug.Log("Removed Scene: " + selectedScene);
        listOfScenes.Remove(selectedScene);
        
        
        Debug.Log("How many scenes left in array " + listOfScenes.Count);

        for(int i = 0; i < listOfScenes.Count; i++)
        {
            //Debug.Log("Scene Track: " + listOfScenes[i]);
            result += listOfScenes[i].ToString() + ", ";
        }

        Debug.Log(result);
    }
}
