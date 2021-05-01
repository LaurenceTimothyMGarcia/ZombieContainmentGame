using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListOfRooms
{
    public static List<int> listOfScenes = new List<int>();

    public static void setArray(int roomFront, int roomEnd)
    {
        for(roomFront = 2; roomFront < roomEnd; roomFront++)
        {
            listOfScenes.Add(roomFront);
        }
    }

    public static List<int> GetArray()
    {
        return listOfScenes;
    }
}
