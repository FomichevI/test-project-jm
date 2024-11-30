using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JsonConverter
{
    public static PackData ConvertToPackData(string packDataString)
    {
        PackDataAdapter adapter = JsonUtility.FromJson<PackDataAdapter>(packDataString);
        PackData data = new PackData();
        data.SetParameters(adapter);
        return data;
    }
}
