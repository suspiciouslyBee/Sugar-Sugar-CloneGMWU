using System;
using System.Collections.Generic;
using UnityEngine;


//"borrowed" from nerd head
public class SerializedDictionary : MonoBehaviour
{

    [SerializeField]
    string thisObjectName;

    [SerializeField]
    NewDict newDict;

    Dictionary<string, GameObject> objectsNames;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectsNames = newDict.ToDictionary();
    }
}
[Serializable]
public class NewDict
{
    [SerializeField]
    NewDictItem[] thisDictItems;

    public Dictionary<string, GameObject> ToDictionary()
    {
        Dictionary<string, GameObject> newDict = new Dictionary<string, GameObject>();

        foreach(var item in thisDictItems)
        {
            newDict.Add(item.name, item.obj);
        }
        return newDict;
    }
}

[Serializable]
public class NewDictItem
{
    [SerializeField]
    public string name;
    [SerializeField]
    public GameObject obj;
}

