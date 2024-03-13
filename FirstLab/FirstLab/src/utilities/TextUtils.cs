using System;
using System.IO;
using System.Windows.Controls;

namespace FirstLab.src.utilities;

public class TextUtils
{
    public static void SetDefaultText(TextBox textBox, string defaultText)
    {
        if (string.IsNullOrWhiteSpace(textBox.Text))
        {
            textBox.Text = defaultText;
        }

    }

    public static void SetEmptyText(TextBox textBox, string defaultText)
    {
        if (textBox.Text == defaultText)
        {
            textBox.Text = string.Empty;
        }
    }

    public static string ReturnDatabaseString()
    {
        try
        {
            string databasePath = @"YOUR_PATH_TO\src\data\myDatabase.db";
            if(File.Exists(databasePath))
                return databasePath;
            else
                throw new Exception();
        }
        catch
        {
            throw new Exception("Database location string malfunctioned in FirstLab/src/utilities/TextUtils.cs");
        }
    }
}
