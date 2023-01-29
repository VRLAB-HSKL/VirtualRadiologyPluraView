using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class DICOMMetaReader : MonoBehaviour
{

    private static readonly string[] metaInformation = new string[50];
    private static float pixelSpacingX;
    private static float pixelSpacingY;
    private static float sliceThickness;


    public static void ReadDICOMMetaInformation()
    {
        var path = ImportRAWModel.MetaTextPath;

        // Resets when you change the model
        pixelSpacingX = 0;
        pixelSpacingY = 0;
        sliceThickness = 0;

        // Check if the model has a corresponding metainfo file
        bool fileValid = IsFileValid(path);

        // When the File exists 
        if (fileValid)
        {
            //StreamReader reads the meta-information of the text file 
            StreamReader streamReader = new StreamReader(path);

            // Safety check
            if (streamReader != null)
            {
                //Displaying additional Information
                metaInformation[0] = "patientname  :   ";
                metaInformation[2] = "patientid    :   ";
                metaInformation[4] = "patientbirthdate :   ";
                metaInformation[6] = "patientsex   :   ";
                metaInformation[8] = "institutionname  :   ";
                metaInformation[10] = "institutionaddress  :   ";
                metaInformation[12] = "physicianname   :   ";
                metaInformation[14] = "studydiscription    :   ";
                metaInformation[16] = "modality    :   ";
                metaInformation[18] = "manufacturer    :   ";
                metaInformation[20] = "studyid     :   ";
                metaInformation[22] = "studydate   :   ";
                metaInformation[24] = "seriesnumber    :   ";
                metaInformation[26] = "pixelspacingx    :   ";
                metaInformation[28] = "pixelspacingy  :   ";
                metaInformation[30] = "slicethickness  :   ";
                metaInformation[32] = "columns :   ";
                metaInformation[34] = "rows    :   ";
                metaInformation[36] = "patientposition     :   ";
                metaInformation[38] = "imageorientationpatientrowx     :   ";
                metaInformation[40] = "imageorientationpatientrowy     :   ";
                metaInformation[42] = "imageorientationpatientrowz     :   ";
                metaInformation[44] = "imageorientationpatientcolumnx     :   ";
                metaInformation[46] = "imageorientationpatientcolumny     :   ";
                metaInformation[48] = "imageorientationpatientcolumnz     :   ";

                for (int i = 1; i < metaInformation.Length; i += 2)
                {
                    metaInformation[i] = streamReader.ReadLine();

                }

                //Parsing the incoming DICOM-Data into unity 
                
                //Converting -> dot to comma because of float parse (american vs european way of writing floats)
                metaInformation[27] = metaInformation[27].Replace(".", ",");
                metaInformation[29] = metaInformation[29].Replace(".", ",");
                metaInformation[31] = metaInformation[31].Replace(".", ",");

                
                pixelSpacingX = float.Parse(metaInformation[27]);
                pixelSpacingY = float.Parse(metaInformation[29]);
                sliceThickness = float.Parse(metaInformation[31]);
                
            }
        }
    }

    public static float GetThickness()
    {
        return sliceThickness;
    }

    public static float GetPixelSpacingX()
    {
        return pixelSpacingX;
    }


    public static float GetPixelSpacingY()
    {
        return pixelSpacingY;
    }

    private static bool IsFileValid(string filePath)
    {
        var IsValid = true;

        if (!File.Exists(filePath))
        {
            IsValid = false;
        }
        else if (Path.GetExtension(filePath).ToLower() != ".txt")
        {
            IsValid = false;
        }

        return IsValid;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
