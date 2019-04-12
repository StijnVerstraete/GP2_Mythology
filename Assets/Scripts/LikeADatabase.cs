using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LikeADatabase
{
    /*
     * Here you can put all the text in it so if you need it you can use it
     * it s like a database, but it isn't :P 
     */

    public static string[] _texts = new string[]
    {
        // First text
        "Kronos, titan of time, was prophesised to be overthrown by one of his children. " +
        "To prevent this, he decided to devour them. " +
        "Hestia, Demeter, Hera, Hades and Poseidon all suffered this fate. " +
        "His wife, Rhea, decided to hide the last one, Zeus. " +
        "When Zeus had grown strong enough, he challenged Kronos and defeated him, " +
        "retrieving his brothers and sisters from the titan's belly.",

        // Second text
        "When Zeus had a relationship with the human Semele, Zeus' wife Hera was unhappy. " +
        "When Semele strode around bragging about her boyfriend being the god of the sky, " +
        "Hera disguised herself as an human and asked Semele if she had any proof he was actually Zeus. " +
        "Peeved, Semele demanded Zeus prove to her his godly nature, by revealing his true glory. " +
        "Zeus refused, but she insisted. When he showed his true self, the glory was too much, " +
        "and Semele disintegrated, leaving behind the unborn baby Dionysos. " +
        "Zeus managed to sow Dionysos into his thigh, where the baby grew healthy. ",

        // Third text
        "Zeus resides on Mount Olympus as king of the gods. " +
        "He rules over the sky and over his brothers, who are kings in their own right. " +
        "Despite being one of the most powerful beings in existence, Zeus' rule is under a constant threat. " +
        "Many Romans believed his son Apollo would overthrow him and become a new king. " +
        "It was prophesised Athena, his daughter, could defeat him if she chose so. " +
        "The titans and older beings clambered for any opportunity to return from their various prisons and take back the power. " +
        "All this caused some of Zeus' behaviour to be erratic and paranoid. "
    };

    public static string[] _titles = new string[] { "First scroll", "Second scroll", "Third scroll" };

    public static string[] _questions = new string[]
    {
        "What did Kronos do to Zeus' siblings?",
        "What happened to Semele?",
        "Where does Zeus rule from?"
    };

    public static string[][] _answers = new string[][]
    {
        new string[]
        {
            "A) He raised them to resent Zeus.",
            "B) He ate them.", // (correct)
            "C) He made them fight each other to the death, until only Zeus was left."
        },
        new string[]
        {
            "A) She was stabbed in the gut by Hera, Zeus' angry wife.",
            "B) She was devoured by her father, but then resqued by her brother, Zeus.",
            "C) She was disintegrated by Zeus' glory." // (correct)
        },
        new string[]
        {
            "A) Mount Olympus.", // (correct)
            "B) The House of Athens.",
            "C) The Great Hill of Singapore."
        }
    };

    public static string[] _correctAnswersList = new string[]
    {
        "B",
        "C",
        "A"
    };
}
