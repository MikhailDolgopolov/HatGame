using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class WordsTable {
    private static readonly string id = "16D0yiKrQk-tan-I0-x0yofEopzgVK9ZO17g-iN9OQ4k";
    private static readonly string sheet = "Hat";
    
    public static int WordsCount;
    private static bool wasInit;
    private static void Init() {
        string fileName = "spreadsheets-320010-ae17360bc1b9";
        TextAsset t = Resources.Load("Text/"+fileName) as TextAsset;
        GoogleSheet.Init(id, t.text);
        GetWordCount();
        wasInit = true;
    }

    public static void Setup() {
        if(!wasInit) Init();
        Thread t = new Thread(GetWordCount);
        t.Start();
    }

    private static void GetWordCount() {
        WordsCount=Int32.Parse(GoogleSheet.GetEntry(sheet, "D1"));
    }
    public static WordRow GetWord(int n) {
        string cell = $"B{n}";
        return new WordRow(GoogleSheet.GetEntry(sheet, cell), n);
    }
    public static string[] GetRange(int end, string col = "B") {
        return GoogleSheet.GetRange(sheet, col, 1, end);
    }
    public static void UpdateCell(string cell, string new_value) {
        GoogleSheet.UpdateEntry(sheet, cell, new_value);
    }
    
    public static void ClearTaken() {
        GoogleSheet.UpdateEntry(sheet, "F1", "ClearTaken");
        Thread.Sleep(2000);
        GoogleSheet.UpdateEntry(sheet, "F1", "");
    }
    public static void DeleteUsed() {
        GoogleSheet.UpdateEntry(sheet, "F2", "DeleteUsed");
        Thread.Sleep(2000);
        GoogleSheet.UpdateEntry(sheet,"F2", "");
    }
    public static void EndGame() {
        ClearTaken();
        DeleteUsed();
    }
}
