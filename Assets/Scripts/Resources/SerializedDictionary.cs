using System;
using System.Collections.Generic;
using UnityEngine;

//"borrowed" from nerd head
//edited to be generic
//only needs to be editable from inspector

//T1: key, T2: value
public class DictionaryWrapper <T1, T2> : MonoBehaviour
{

    [SerializeField]
    SerializedDictionary<T1,T2> newDict;

    Dictionary<T1, T2> objectsNames;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectsNames = newDict.ToDictionary();
    }
}
[Serializable]
public class SerializedDictionary <T1, T2>
{
    [SerializeField]
    SerializedDictItem<T1, T2>[] thisDictItems;

    public Dictionary<T1, T2> ToDictionary()
    {
        Dictionary<T1, T2> newDict = new Dictionary<T1, T2>();

        foreach(var item in thisDictItems)
        {
            newDict.Add(item.key, item.value);
        }
        return newDict;
    }
}

[Serializable]
public class SerializedDictItem <T1, T2>
{
    [SerializeField]
    public T1 key;
    [SerializeField]
    public T2 value;
}

