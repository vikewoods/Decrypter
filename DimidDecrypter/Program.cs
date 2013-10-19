using System;

namespace DimidDecrypter
{
  class MainClass
  {
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
          byte[] decrypted64 = Convert.FromBase64String (inputForDecrypt);
          string result = System.Text.Encoding.UTF8.GetString (decrypted64);
          Console.WriteLine ("Decrypted text: " + result);
        }// If input 2 end
        // If input equal 3 lets terminate application
        if(inputFromConsole == "3"){
          Environment.Exit (0);
        }
      }// Loop
    }// Main function
  }
}
