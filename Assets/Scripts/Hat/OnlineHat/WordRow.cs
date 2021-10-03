using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WordRow : IWord{
    public string content { get; private set; }
    public int row;
    private bool toDelete;
    public string Spot
    {
        get { return "B" + row; }
    }

    public string StatusCell
    {
        get { return "C" + row; }
    }

    public static implicit operator string(WordRow w) => w.content;

    public override string ToString() {
        return content;
    }

    public string GetString() {
        return content;
    }
    public WordRow(string word, int r) {
        content = word;
        row = r;
    }

    public bool needsDeleting() {
        return toDelete;
    }

    #region Delete

    public void DeleteAsync() {
        Delete(true);
    }

    public void Delete() {
        Delete(false);
    }
    private void Delete(bool newThread) {
        string parameter = "Delete";
        if(!newThread){ ChangeStatus(parameter);
            return;
        }
        Thread t = new Thread(ChangeStatus);
        t.Start(parameter);
    }
    #endregion
    #region Take
    public void TakeAsync() {
        Take(true);
    }
    public void Take() {
        Take(false);
    }
    private void Take(bool newThread) {
        string parameter = "Taken";
        if(!newThread){ ChangeStatus(parameter);
            return;
        }
        Thread t = new Thread(ChangeStatus);
        t.Start(parameter);
    }
    #endregion
    #region Free

    public void FreeAsync() {
        Free(true);
    }
    public void Free() {
        Free(false);
    }
    private void Free(bool newThread) {
        string parameter = "";
        if(!newThread){ ChangeStatus(parameter);
            return;
        }
        Thread t = new Thread(ChangeStatus);
        t.Start(parameter);
    }
    #endregion
    public void ChangeStatus(object status) {
        toDelete = true;
        WordsTable.UpdateCell(StatusCell, (string)status);
    }
}
