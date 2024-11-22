// See https://aka.ms/new-console-template for more information

using Project.classes;
using Project.managers;

namespace Project;

internal class Program
{
    public static void Main(string[] args)
    {

        Menu menu = new Menu();
        menu.Start();
    }
}