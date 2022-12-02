using UnityEngine;
using System.IO;
using System.Xml.Linq;

public static class DataResponsable
{
    private static PlayerData _playerData;

    private static readonly string path = Application.persistentDataPath + "data.xml";

    public static PlayerData PlayerData
    {
        get
        { 
            return _playerData; 
        }
        set
        {
            _playerData = value;
        }
    }

    static DataResponsable()
    {
        _playerData = new PlayerData();
        GetData();
    }

    private static void GetData()
    {
        retry:
        if (File.Exists(path))
        {
            XElement root = new XElement("Root");
            root = XDocument.Parse(File.ReadAllText(path)).Element("Root");

            _playerData.CoinsCount = int.Parse(root.Element("CoinsCount").Value);
            _playerData.BestScore = int.Parse(root.Element("BestScore").Value);
        }
        else
        {
            SaveData(); //Создаем файл с начальными данными и сохраняем его
            goto retry;
        }
    }

    public static void SaveData()
    {
        XElement root = new XElement("Root");

        XElement coinsCount = new XElement("CoinsCount");
        XElement bestScore = new XElement("BestScore");

        coinsCount.Add(_playerData.CoinsCount);
        bestScore.Add(_playerData.BestScore);

        root.Add(coinsCount);
        root.Add(bestScore);

        XDocument file = new XDocument(root);

        File.WriteAllText(path, file.ToString());
    }
}
