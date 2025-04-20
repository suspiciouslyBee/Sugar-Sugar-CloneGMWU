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
        return GetDictionary().Values.Count();
    }



}
