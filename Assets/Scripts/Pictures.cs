using System.Collections;
using System.Collections.Generic;
using System;

/*
 * Storage and access for all the different pictures that users can try to draw
 */
public static class Pictures
{
    private static Random rand;

    private static string[] WordList = 
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
    };

// TODO: add words as well as way to generate words
public static string generateWord()
    {
        // Instantiate rand if not instantiated yet
        if (rand == null)
        {
            rand = new Random();
        }
        
        return WordList[rand.Next(WordList.Length)];
    }
}
