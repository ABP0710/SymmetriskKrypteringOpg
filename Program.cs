// See https://aka.ms/new-console-template for more information

using SymmetriskKrypteringOpg;
using System.Diagnostics;
using System.Text;

string testText = "En meget hemmelig tekst, der ikke må læses af andre";

// DES

var des = new DES();
var desKey = des.GenerateRandomNumber(8);
var desIV = des.GenerateRandomNumber(8);

var desEncrypted = des.Encrypt(Encoding.UTF8.GetBytes(testText), desKey, desIV);
var desDecrypted = des.Decrypt(desEncrypted, desKey, desIV);

var desDecryptedText = Encoding.UTF8.GetString(desDecrypted);

//tripleDES

var tripleDes = new TripleDES();
var tripleDesKey = tripleDes.GenerateRandomNumber(16);
var tripleDesIv = tripleDes.GenerateRandomNumber(8);

var tripleEncrypted = tripleDes.Encrypt(Encoding.UTF8.GetBytes(testText), tripleDesKey, tripleDesIv);
var tripleDeccrypted = tripleDes.Decrypt(tripleEncrypted, tripleDesKey, tripleDesIv);

var tripleDecryptedText = Encoding.UTF8.GetString(tripleDeccrypted);

//AES

var aes = new AES();
var aesKey = aes.GenerateRandomNumber(32);
var aesIV = aes.GenerateRandomNumber(16);

var aesEncrypted = aes.Encrypt(Encoding.UTF8.GetBytes(testText), aesKey, aesIV);
var aesDecrypted = aes.Decrypt(aesEncrypted, aesKey, aesIV);

var aesDecryptedText = Encoding.UTF8.GetString(aesDecrypted);

Console.WriteLine("DES");
Console.WriteLine();
Console.WriteLine("Første tekst: " + testText);
Console.WriteLine("Kryptered tekst: " + Convert.ToBase64String(desEncrypted));
Console.WriteLine("Dekrytered tekst: " + desDecryptedText);
Console.WriteLine();
Console.WriteLine("TripleDES:");
Console.WriteLine();
Console.WriteLine("Første tekst: " + testText);
Console.WriteLine("Kryptered tekst: " + Convert.ToBase64String(tripleEncrypted));
Console.WriteLine("Dekrytered tekst: " + tripleDecryptedText);
Console.WriteLine();
Console.WriteLine("AES:");
Console.WriteLine();
Console.WriteLine("Første tekst: " + testText);
Console.WriteLine("Kryptered tekst: " + Convert.ToBase64String(aesEncrypted));
Console.WriteLine("Dekrytered tekst: " + aesDecryptedText);
