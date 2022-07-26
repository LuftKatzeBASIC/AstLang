using System;
using System.IO;

namespace AstLang
{
    class Program
    {

        static short pr = 0;
        static string todo = "";
        static string filename = "";
        static bool AllowInlineAsm = false;
        static string AllowedChars = "0123456789x, ";

        static void Main(string[] args)
        {
            Console.WriteLine("AstLang ver 0.5");
            Console.WriteLine(@"               _   _                       ");
            Console.WriteLine(@"     /\       | | | |                      ");
            Console.WriteLine(@"    /  \   ___| |_| |     __ _ _ __   __ _ ");
            Console.WriteLine(@"   / /\ \ / __| __| |    / _` | '_ \ / _` |");
            Console.WriteLine(@"  / ____ \\__ \ |_| |___| (_| | | | | (_| |");
            Console.WriteLine(@" /_/    \_\___/\__|______\__,_|_| |_|\__, |");
            Console.WriteLine(@"                                      __/ |");
            Console.WriteLine(@"                                     |___/ ");
            Console.ResetColor();

            if (args.Length != 0)
            {
                for(int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "--COM":
                            todo = "COM";
                            break;
                        case "--AllowInlineAsm":
                            AllowInlineAsm = true;
                            break;
                        case "--help":
                            Console.WriteLine("AstLang v0.5 Compiler v1.3\n2022, Luftkatze\n");
                            return;
                        case "--abt":
                            Console.WriteLine("D o ( n ' t )   u s e   t h i z   p l z");
                            return;
                        case "--icantcodeinthisthingplzhelp":
                            Console.WriteLine("Bro i cant code in thiz thing too ://\n");
                            break;
                        default:
                            if (filename != "")
                            {
                                Console.WriteLine("?????????????");
                                return;
                            }
                            filename = args[i];
                            break;
                    }
                }
            }
            switch (todo)
            {
                case "COM":
                    CompileDOS();
                    break;
                case "":
                    break;
            }
        }

        static void CompileDOS()
        {
            if(filename=="" || !File.Exists(filename))
            {
                Console.WriteLine($"sorri but me blind cant find file {filename} :////");
                return;
            }
            string[] file = File.ReadAllLines(filename);
            string output = $"org 0x100\n; {DateTime.Now.ToString()}\n";
            for(int II = 0; II < file.Length; II++)
            {
                string line = file[II];
                for(int i = 0; i < line.Length; i++)
                {
                    if (line.Length < 3)
                    {
                        break;
                    }
                    if (line.Length == 3)
                    {
                        line += " ";
                    }
                    string expr = line.Remove(3, line.Length - 3);
                    switch (expr)
                    {
                        case "bai":
                            output += "int 0x20\n";
                            break;
                        case "KwK":
                            output += "nop\n";
                            break;
                        case "OwO":
                            if (!Int16.TryParse(line.Remove(0, 4), out pr)) { throw new Exception("Bad user! Bad!"); }
                            output += $"mov ax, {pr}\n";
                            break;
                        case "UwU":
                            if (!Int16.TryParse(line.Remove(0, 4), out pr)) { throw new Exception("Bad user! Bad!"); }
                            output += $"mov ax, [{pr + 0x100}]\n";
                            break;
                        case "QwQ":
                            if (!Int16.TryParse(line.Remove(0, 4), out pr)) { throw new Exception("Bad user! Bad!"); }
                            output += $"mov [{pr + 0x100}], ax\n";
                            break;
                        case ">w<":
                            if (!Int16.TryParse(line.Remove(0, 4), out pr)) { throw new Exception("Bad user! Bad!"); }
                            output += $"add [{pr + 0x100}], ax\n";
                            break;
                        case "._.":
                            if (!Int16.TryParse(line.Remove(0, 4), out pr)) { throw new Exception("Bad user! Bad!"); }
                            output += $"sub [{pr + 0x100}], ax\n";
                            break;
                        case "*w*":
                            if (!Int16.TryParse(line.Remove(0, 4), out pr)) { throw new Exception("Bad user! Bad!"); }
                            output += $"mul word [{pr + 0x100}]\n";
                            break;
                        case ">->":
                            if (!Int16.TryParse(line.Remove(0, 4), out pr)) { throw new Exception("Bad user! Bad!"); }
                            output += $"jmp {pr+0x100}\n";
                            break;
                        case "^w^":
                            if (!Int16.TryParse(line.Remove(0, 4), out pr)) { throw new Exception("Bad user! Bad!"); }
                            output += $"cmp ax, [{pr + 0x100}]\n";
                            break;
                        case "^-^":
                            if (!Int16.TryParse(line.Remove(0, 4), out pr)) { throw new Exception("Bad user! Bad!"); }
                            output += $"je {pr + 0x100}\n";
                            break;
                        case "'w'":
                            if (!Int16.TryParse(line.Remove(0, 4), out pr)) { throw new Exception("Bad user! Bad!"); }
                            output += $"jne {pr + 0x100}\n";
                            break;
                        case "heh":
                            if (!Int16.TryParse(line.Remove(0, 4), out pr)) { throw new Exception("Bad user! Bad!"); }
                            output += $"jl {pr + 0x100}\n";
                            break;
                        case "VwV":
                            if (!Int16.TryParse(line.Remove(0, 4), out pr)) { throw new Exception("Bad user! Bad!"); }
                            output += $"jg {pr + 0x100}\n";
                            break;
                        case "#w#":
                            if (!Int16.TryParse(line.Remove(0, 4), out pr)) { throw new Exception("Bad user! Bad!"); }
                            output += $"call {pr + 0x100}\n";
                            break;
                        case "plz":
                            output += "mov ah, 0x01\nint 0x21\nmov dl, al\nxor ax,ax\nmov al, dl\n";
                            break;
                        case "4yu":
                            output += "push ax\nmov ah, 0x02\nmov dl, al\nint 0x21\npop ax\n";
                            break;
                        case ";-;":
                            output += $"; {line.Remove(0,3)}\n";
                            break;
                        case "pof":
                            output += $"push ax\nmov ax, 0x03\nint 0x10\npop ax\n";
                            break;
                        case "brb":
                            output += $"int 0x27\n";
                            break;
                        case "oki":
                            output += "ret\n";
                            break;
                        case "asm":
                            if (AllowInlineAsm)
                                output += $"{line.Remove(0, 4)}\n";
                            else
                                throw new Exception("Inline Assembly isn't allowed brouuuu ://////////////");
                            break;
                        case "~w~":
                            for(int ik = 4; ik < line.Length; ik++)
                            {
                                if (!AllowedChars.Contains(line[i]))
                                {
                                    throw new Exception("Bad user! Bad!");
                                }
                            }
                            output += $"db {line.Remove(0,4)}\n";
                            break;
                        case "+w+":
                            output += "inc ax\n";
                            break;
                        case "=w=":
                            output += "dec ax\n";
                            break;
                        case ">>>":
                            output += "push ax\n";
                            break;
                        case "<<<":
                            output += "pop ax\n";
                            break;
                        default:
                            line = line.Remove(0, 1);
                            continue;
                    }
                    line = line.Remove(0, 3);
                }
            }
            if(!output.EndsWith("int 0x20\n"))
            {
                output += "int 0x20\n";
            }
            if (File.Exists("uwu.asm"))
            {
                File.WriteAllBytes("uwu.bak", File.ReadAllBytes("uwu.asm"));
                Console.WriteLine("Me doznt want to destroi ur work so me copied 'uwu.asm' to 'uwu.bak' >-<");
            }
            File.WriteAllText("uwu.asm", output);
        }
        
    }
}
