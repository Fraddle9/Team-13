using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWriter : MonoBehaviour
{
    private static TextWriter instance;
    private List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    public static TextWriterSingle AddWriter_Static(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd)
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        return instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters);
    }
    private TextWriterSingle AddWriter(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
    }

    public static void RemoveWriter_Static(TextMeshProUGUI uiText)
    {
        instance.RemoveWriter(uiText);
    }
    private void RemoveWriter(TextMeshProUGUI uiText)
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            if (textWriterSingleList[i].GetUIText() == uiText)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    private void Update()
    {
        //Debug.Log(textWriterSingleList.Count);
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            bool destroyInstance = textWriterSingleList[i].Update();
            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
        
    }

    /*
     *Tek örneði instance et.
     */
    public class TextWriterSingle
    {
        private TextMeshProUGUI uiText;
        private string textToWrite;
        private int characterIndex;
        private float timePerCharacter;
        private float timer;
        private bool invisibleCharacters;
        public TextWriterSingle(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
        }

        //True döndürürse tamamlandý.
        public bool Update()
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                //Sonraki karakteri göster
                timer += timePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                uiText.SetText(text);

                if (characterIndex >= textToWrite.Length)
                {
                    //Tüm mesaj görüntülendi
                    return true;
                }
            }

            return false;
        }

        public TextMeshProUGUI GetUIText()
        {
            return uiText;
        }

        public bool IsActive()
        {
            return characterIndex < textToWrite.Length;
        }

        public void WriteAllAndDestroy()
        {
            uiText.SetText(textToWrite);
            characterIndex = textToWrite.Length;
            TextWriter.RemoveWriter_Static(uiText);
        }
    }
}
