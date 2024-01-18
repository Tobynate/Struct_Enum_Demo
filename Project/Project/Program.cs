// See https://aka.ms/new-console-template for more information

using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
class Program
{
    static void Main(string[] args) // Main entry point
    {
        CardLogic.Shuffle();
    }
}
public enum NumIdentifier
{
    Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
}
public enum ShapeIdentifier
{
    Spades, Hearts, Diamonds, Clubs
}

struct Representation
{
    public string[] GetCardRepresentation(int numIndex, int shapeIndex)
    {
        string[] output = [((NumIdentifier)numIndex).ToString(), ((ShapeIdentifier)shapeIndex).ToString()];
        return output;
    }
}

static class CardLogic
{
    static object[] _deckarray = new object[52];

    public static void Shuffle()
    {
        Random random = new();

        Representation representation = new();
        for (int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 13; j++)
            {
                if (i == 0) _deckarray[j] = representation.GetCardRepresentation(j, i);
                else _deckarray[13 * i + j] = representation.GetCardRepresentation(j, i);
            }
        }

        if(_deckarray.Length > 1) random.Shuffle(_deckarray);
        for (int i = 0; i < _deckarray.Length; i++)
        {
            Console.WriteLine(((string[])_deckarray[i])[0] + " of " + ((string[])_deckarray[i])[1]);
        }
        
        Console.Read();
    }
}

