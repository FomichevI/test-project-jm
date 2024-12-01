using UnityEngine;

// �����, ���������� �� ����������� ������ � ���� Json ������ � ��������� ������������ ��� ������.
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
