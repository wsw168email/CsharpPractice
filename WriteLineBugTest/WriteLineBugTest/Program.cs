// See https://aka.ms/new-console-template for more information
string strTest = "";
for (int i = 0; i < 10; i++) 
{
    string test = Convert.ToString(i);
    strTest += test;
}
Console.WriteLine("" + strTest[0] + strTest[1] + strTest[2] + strTest[3] + strTest[4] + strTest[5] + strTest[6] + strTest[7] + strTest[8] + strTest[9] );