﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;

namespace DTS_Addon
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class xMenu : MonoBehaviour
    {
        List<string> mytips = new List<string>();

        void Start()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(File.OpenRead("GameData/DTS_zh/zhLoadingTips.xml"));
            foreach (XmlElement item in doc.DocumentElement.ChildNodes)
            {
                mytips.Add("" + (String)item.InnerText);
            }
        }


        string nowText = "";
        TextMesh loadText;
        System.Random random = new System.Random();

        void Update()
        {
            if (loadText == null)
            {
                var go = GameObject.Find("Text");
                if (go == null) return;

                loadText = go.GetComponent<TextMesh>();
                loadText.fontSize = 16;
            }

            if (nowText != loadText.text)
            {
                int c = random.Next(mytips.Count);
                loadText.text = "深度时空荣誉汉化...\r\n\r\n" + mytips[c];
                nowText = loadText.text;
                if (mytips.Count > 1)
                    mytips.RemoveAt(c);
            }
        }
    }
}
