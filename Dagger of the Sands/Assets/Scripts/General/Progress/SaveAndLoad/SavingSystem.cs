using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO; 

public static class SavingSystem
{

    public static void SavePlayer(PlayerController player) 
    {
        Debug.Log("Saving");
        //Formattes data into binary
        BinaryFormatter formatter = new BinaryFormatter();

        //Create a path in a data directory.
        string path = Application.persistentDataPath + "/PlayerData.DOS";

        //Create a save data file in the path. 
        FileStream stream = new FileStream(path, FileMode.Create);

        //Gets the player data.
        PlayerData data = new PlayerData(player);

        //Writes the data into the file.
        formatter.Serialize(stream, data);

        //Closes the file.
        stream.Close();
        Debug.Log("Saving is Done");
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/PlayerData.DOS";

        if (File.Exists(path))
        {
            //Formattes the data into binary.
            BinaryFormatter formatter = new BinaryFormatter();

            //Locate and open the already created file.
            FileStream stream = new FileStream(path, FileMode.Open);

            //Input the date in the file into a new variable, using "as PlayerData" as a formatte (Casting it).
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            
            //Close the file.
            stream.Close();


            return data;
        }
        else
        {
            Debug.LogError("Save File not found " + path);
            return null;
        }
    }

}
