using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class DialogueImporter
{

    public static Dictionary<string, Dialogue> ImportCharacterDialogue()
    {
        TextAsset[] files = Resources.LoadAll<TextAsset>("CharacterDialogue");
        Dictionary<string, Dialogue> characterDialogue = new Dictionary<string, Dialogue>();
        foreach (TextAsset asset in files)
        {
            string text = asset.text;
            string[] splitIndicators = { "C:", "M:", "I:" };
            string[] speech = text.Split(splitIndicators, new System.StringSplitOptions());
            Dialogue d = new Dialogue();
            d.name = asset.name;
            d.sentences = speech;
            characterDialogue.Add(d.name, d);
        }
        return characterDialogue;
    }

}
