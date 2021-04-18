using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListOfRooms
{
    public static List<int> listOfScenes = new List<int>();

    public static void setArray()
    {
        for(int i = 0; i < 6; i++)
        {
            listOfScenes.Add(i);
            Debug.Log("Setting Array Scene Track: " + listOfScenes[i]);
        }
    }

    public static List<int> GetArray()
    {
        /*for(int i = 0; i < listOfScenes.Count; i++)
        {
            Debug.Log("Setting Array Scene Track: " + listOfScenes[i]);
        }*/
        return listOfScenes;
    }
}
