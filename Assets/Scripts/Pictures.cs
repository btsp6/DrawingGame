using System.Collections;
using System.Collections.Generic;
using System;

/*
 * Storage and access for all the different pictures that users can try to draw
 */
public static class Pictures
{
    private static Random rand = new Random();

    private static string[][] WordTrips =
    {
        new string[] {"elephant", "spider", "butterfly"},
        new string[] {"smile", "sad", "eyes"},
        new string[] {"cookie", "cupcake", "sandwich"},
        new string[] {"apple", "grapes", "cherry"},
        new string[] {"Christmas tree", "star", "butterfly"}
    };

    // from https://stackoverflow.com/a/1262619
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static string[] getWordTrip()
    {
        string[] ret = (string[]) WordTrips[rand.Next(WordTrips.Length)].Clone();
        ret.Shuffle<string>();
        return ret;
    }

    /*private static string[] WordList = 
    {
        "jack-o'-lantern",
        "elephant",
        "ocean",
        "book",
        "egg",
        "house",
        "dog",
        "ball",
        "star",
        "shirt",
        "underwear",
        "ice cream",
        "drum",
        "Christmas tree",
        "spider",
        "shoe",
        "smile",
        "cup",
        "hat",
        "cookie",
        "bird",
        "kite",
        "snowman",
        "butterfly",
        "cupcake",
        "fish",
        "grapes",
        "socks",
        "TV",
        "bed",
        "phone",
        "doll",
        "trash can",
        "skateboard",
        "sleep",
        "sad",
        "airplane",
        "nose",
        "eyes",
        "apple",
        "sun",
        "sandwich",
        "cherry",
        "bubble",
        "moon",
        "snow",
        "candy",
        "roof"
    };*/

    

// TODO: add words as well as way to generate words
/*
public static string generateWord()
    {
        // Instantiate rand if not instantiated yet
        if (rand == null)
        {
            rand = new Random();
        }
        
        return WordList[rand.Next(WordList.Length)];
    }*/
}
