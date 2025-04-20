using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MugColors : SerializedDictionary<Color, int>
{
    public int RemainingTotalSugar()
    {
        return GetDictionary().Values.Sum();
    }

    public int ColorCount()
    {
        DEBUG_dumpDict();
        return GetDictionary().Values.Count();
    }

    public void DEBUG_dumpDict()
    {
        Dictionary<Color, int> dumped = GetDictionary();
        Debug.Log("Dumping Dictionary\n" +
            "Item Count : " + dumped.Values.Count() + "\n" +
            "Item Dump proceeding");

        foreach(KeyValuePair<Color, int> entry in dumped)
        {
            Debug.Log("Color : " + entry.Key + "Remaining : " + entry.Value);
        }
    }



}
