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
        if(listOfScenes.Count == 0)
        {
            ListOfRooms.setArray();
        }
        listOfScenes = ListOfRooms.GetArray();
        Debug.Log("moveing to next Room");

        /*if(listSize < 1)
        {
            Debug.Log("Thanks for playing");
            return;
        }*/
        listSize = listOfScenes.Count;
        arrayNumber = Random.Range(0, listSize);
        selectedScene = listOfScenes[arrayNumber];

        SceneManager.LoadScene(selectedScene);
        listOfScenes.Remove(arrayNumber);
        
        Debug.Log("This is the scene that was loaded " + selectedScene);
        Debug.Log("How many scenes left in array " + listOfScenes.Count);

        for(int i = 0; i < listOfScenes.Count; i++)
        {
            Debug.Log("Scene Track: " + listOfScenes[i]);
        }
    }
}
