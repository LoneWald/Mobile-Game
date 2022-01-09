using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;     //запись и чтение xml файла
using System.IO;

[XmlRoot("dialogue")]
public class Dialogue
{

    [XmlElement("text")]
    public string text;

    [XmlElement("node")]
    public Node[]  nodes;

    public static Dialogue Load(TextAsset _xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Dialogue));
        StringReader reader = new StringReader(_xml.text);
        Dialogue dial = serializer.Deserialize(reader) as Dialogue;
        return dial;
    }
}

[System.Serializable]
public class Node
{
    [XmlElement("npctext")]
    public string npcText;

    [XmlArray("answers")]
    [XmlArrayItem("answer")]
    public Answer[] answers;
}

public class Answer
{
    [XmlAttribute("tonode")]
    public int nextNode;
    [XmlElement("text")]
    public string text;
    [XmlElement("exit")]
    public string end;
    [XmlElement("quest")]
    public int? quest;
    [XmlElement("questEnd")]
    public int? questEnd;
}
