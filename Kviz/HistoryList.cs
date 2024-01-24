using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Kviz
{
    public static class HistoryList//
    {
        const string fileName = "history.xml";//jmeno souboru pro historii
        static string name = "anonym";//pokud uživatel nezadal jméno bude se jmenovat "anonym"
        public static void addHistoryElemnts()//tahle funkce se volá v třidě "Result", po ukončeni pokusu
        {
            List<HistoryElement> existingData = deserialize() ?? new List<HistoryElement>();//deserializuje existujici historie, pokud jsou

            if (existingData.Count > 11)//do historie se uklada jenom 12 posleních pokusů
            {
                for (int i = 1; i < existingData.Count; i++)
                {
                    existingData[i - 1] = existingData[i];
                }
                existingData.RemoveAt(existingData.Count - 1);
            }

            if (Start.userName != null)
            {
                name = Start.userName;//pokud uživatel zadal jméno, přiřádi mu jmeno
            }
            DateTime dateAndTime = DateTime.Now;//zapiše datum a čas pokusu
            HistoryElement history = new HistoryElement(name, dateAndTime, Result.result);//naplnuje jednotku historii
            existingData.Add(history);//přida jednotku historii k listu
            XmlSerializer serializer = new XmlSerializer(typeof(List<HistoryElement>));

            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fileStream, existingData);//serealizuje upravený list
            }
        }

        public static List<HistoryElement> deserialize()//deserializuje historie
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<HistoryElement>));
            try
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    List<HistoryElement> deserializedList = (List<HistoryElement>)serializer.Deserialize(fileStream);
                    return deserializedList;
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }

        }


    }
}
