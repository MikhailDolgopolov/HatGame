using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using UnityEngine;
using Debug = UnityEngine.Debug;

static class GoogleSheet {
    private static readonly string[] Scopes = {SheetsService.Scope.Spreadsheets};
    public static string Id;
    private static SheetsService service;
    public static void Init(string TableId, string ClientKey_Json) {
        BaseClientService.Initializer init = new BaseClientService.Initializer();
        Id = TableId;
        GoogleCredential credential=GoogleCredential.FromJson(ClientKey_Json);
        credential.CreateScoped(Scopes);
        init.HttpClientInitializer = credential;
        service = new SheetsService(init);
    }
    
    public static string GetEntry(string sheet, string cell) {
        string range = $"{sheet}!{cell}";
        var request = service.Spreadsheets.Values.Get(Id, range);
        var response = request.Execute();
        var valueList = response.Values;
        if (valueList == null) return "";
        var value = valueList[0][0];
        return value.ToString();
    }
    public static string[] GetRange(string sheet, string col, int start, int end) {
        string range = $"{sheet}!{col}{start}:{col}{end}";
        int number = end - start + 1;
        var request = service.Spreadsheets.Values.Get(Id, range);
        var response = request.Execute();
        var valueList = response.Values;
        if (valueList == null) return new string[]{""};
        string[] result = new string[valueList.Count];
        for (int i = 0; i<valueList.Count;i++) {
            
            result[i] = valueList[i][0].ToString();
        }
        return result;
    }
    
    public static void AddEntry(string sheet, string cell, string entry) {
        string range = $"{sheet}!{cell}";
        ValueRange valRange = new ValueRange();
        var objectList = new List<object>() {entry};
        valRange.Values = new List<IList<object>> {objectList};
        var appendRequest = service.Spreadsheets.Values.Append(valRange, Id, range);
        appendRequest.ValueInputOption =
            SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
        var response = appendRequest.Execute();
    }
    public static void UpdateEntry(string sheet, string cell, string new_entry) {
        string range = $"{sheet}!{cell}";
        ValueRange valRange = new ValueRange();
        var objectList = new List<object>() {new_entry};
        valRange.Values = new List<IList<object>> {objectList};
        var appendRequest = service.Spreadsheets.Values.Update(valRange, Id, range);
        appendRequest.ValueInputOption =
            SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
        var response = appendRequest.Execute();
    }
}
