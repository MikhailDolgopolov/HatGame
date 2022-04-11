using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WordRefinery {
    private static string[] splitChars = new[] {" ", ", "};

    public static string[] Split(string line) {
        line = line.ToLower();
        return line.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    }

    public static void PrintArray(string[] array) {
        if(array==null) {
            return;
        }
        String result = "[";
        for (int i = 0; i < array.Length; i++) {
            result += "     ";
            result += array[i];
            result += Environment.NewLine;
            if (i < array.Length - 1) {
                result += ", ";
            }
        }

        result += "]";
        Debug.Log(result);
    }
    
}
