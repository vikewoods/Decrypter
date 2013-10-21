using System;
using System.Linq;
using System.Collections.Generic;


namespace DimidDecrypter
{
  class MainClass
  {
    private static readonly HashSet<char> _base64Characters = new HashSet<char>() { 
      'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 
      'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 
      'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 
      'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/', 
      '='
    };

    public static void Main (string[] args)
    {
      //Console.WriteLine ("Hello World!");
      while (true) {
        Console.WriteLine ("[1] - Encrypted");
        Console.WriteLine ("[2] - Decrypt");
        Console.WriteLine ("[3] - Terminate");

        string inputFromConsole = Console.ReadLine ();
        // Cath input from user
        // If input equal 1 lets encrypt line
        if (inputFromConsole == "1") {
          Console.Write ("Type some text: ");
          string inputForEncrypt = Console.ReadLine ();
          byte[] utf8ForEncrypt = System.Text.UTF8Encoding.UTF8.GetBytes (inputForEncrypt);
          string encryptedLine = Convert.ToBase64String (utf8ForEncrypt);
          Console.WriteLine ("Encrypted line: " + encryptedLine);
        }// If input 1 end
        // If input equal 2 lets decrypt encrypted string
        if(inputFromConsole == "2"){
          Console.Write ("Input base64 string: ");
          string inputForDecrypt = Console.ReadLine ();
          while(IsBase64String(inputForDecrypt)){
            byte[] decrypted64 = Convert.FromBase64String (inputForDecrypt);
            string result = System.Text.Encoding.UTF8.GetString (decrypted64);
            Console.WriteLine ("Decrypted text: " + result);
          }
          Console.WriteLine ("Input is not valid base64 string!");

        }// If input 2 end
        // If input equal 3 lets terminate application
        if(inputFromConsole == "3"){
          Environment.Exit (0);
        }
      }// Loop
    }// Main function
   
    public static bool IsBase64String(string value)
    {
      if (string.IsNullOrEmpty(value))
      {
        return false;
      }
      else if (value.Any(c => !_base64Characters.Contains(c)))
      {
        return false;
      }

      try
      {
        Convert.FromBase64String(value);
        return true;
      }
      catch (FormatException)
      {
        return false;
      }
    }
  }
}
