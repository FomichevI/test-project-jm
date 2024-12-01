using UnityEngine;

//  ласс, отвечающий за конвертацию данных в виде Json строки в экземпл€р необходимого нам класса.
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
