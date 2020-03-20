﻿namespace KMA.ProgrammingInCSharp2019.Lab1.IntroToAstrology.Tools.Navigation
{
    internal enum ViewType
    {
        DataGrid,
        PersonOperation,
    }

    internal interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
