﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsvDataReader3D : MonoBehaviour
{
    public TextAsset Asset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Vector3> GetData()
    {
        if (this.Asset == null)
        {
            return new List<Vector3>();
        }

        List<Vector3> data = new List<Vector3>();

        // Extract the lines from the CSV file.
        string[] lines = this.Asset.text.Split('\n');

        // Print a warning to the Unity console if the file is found to be empty.
        //      Note that the foreach loop below will not execute in this case,
        //      and the empty list of vectors will be returned.
        if (lines.Length == 0)
        {
            Debug.LogWarning("Empty input file");
        }

        // For each line...
        foreach (string line in lines)
        {
            // Extract the values on that line.
            string[] values = line.Split(',');

            // If the line doesn't contain exactly three values, move on to the next.
            if (values.Length != 3)
            {
                // Print an error message to Unity console showing line number and content
                //      that caused the error.
                Debug.LogError("Error parsing line #" + (new List<string>(lines)).IndexOf(line) + ": " + line);
                continue;
            }

            // Parse the values
            float x;
            float y;
            float z;

            try
            {
                x = float.Parse(values[0]);
                y = float.Parse(values[1]);
                z = float.Parse(values[2]);
            }
            catch
            {
                // Print an error message to Unity console showing line number and content
                //      that caused the error.
                Debug.LogError("Error parsing line #" + (new List<string>(lines)).IndexOf(line) + ": " + line);
                continue;
            }

            // Add a new vector containing the parsed data from the line to the list of
            //      vectors.
            data.Add(new Vector3(x, y, z));
        }

        // Return the completed list of vectors.
        return data;
    }
}