﻿namespace ConsoleApp1.Input
{
    internal interface IInputProvider
    {
        void GetInput(out eInputAction newInput);
    }
}
