﻿using System;
using System.Collections.Generic;

namespace Kata
{
    public class ElementalWords
    {
        static Dictionary<string, string> periodicTable = new Dictionary<string, string>()
        {
            { "H", "Hydrogen" }, { "He", "Helium" }, { "Li", "Lithium" }, { "Be", "Beryllium" },
            { "B", "Boron" }, { "C", "Carbon" }, { "N", "Nitrogen" }, { "O", "Oxygen" },
            { "F", "Fluorine" }, { "Ne", "Neon" }, { "Na", "Sodium" }, { "Mg", "Magnesium" },
            { "Al", "Aluminium" }, { "Si", "Silicon" }, { "P", "Phosphorus" }, { "S", "Sulfur" },
            { "Cl", "Chlorine" }, { "Ar", "Argon" }, { "K", "Potassium" }, { "Ca", "Calcium" },
            { "Sc", "Scandium" }, { "Ti", "Titanium" }, { "V", "Vanadium" }, { "Cr", "Chromium" },
            { "Mn", "Manganese" }, { "Fe", "Iron" }, { "Co", "Cobalt" }, { "Ni", "Nickel" },
            { "Cu", "Copper" }, { "Zn", "Zinc" }, { "Ga", "Gallium" }, { "Ge", "Germanium" },
            { "As", "Arsenic" }, { "Se", "Selenium" }, { "Br", "Bromine" }, { "Kr", "Krypton" },
            { "Rb", "Rubidium" }, { "Sr", "Strontium" }, { "Y", "Yttrium" }, { "Zr", "Zirconium" },
            { "Nb", "Niobium" }, { "Mo", "Molybdenum" }, { "Tc", "Technetium" }, { "Ru", "Ruthenium" },
            { "Rh", "Rhodium" }, { "Pd", "Palladium" }, { "Ag", "Silver" }, { "Cd", "Cadmium" },
            { "In", "Indium" }, { "Sn", "Tin" }, { "Sb", "Antimony" }, { "Te", "Tellurium" },
            { "I", "Iodine" }, { "Xe", "Xenon" }, { "Cs", "Caesium" }, { "Ba", "Barium" },
            { "La", "Lanthanum" }, { "Ce", "Cerium" }, { "Pr", "Praseodymium" }, { "Nd", "Neodymium" },
            { "Pm", "Promethium" }, { "Sm", "Samarium" }, { "Eu", "Europium" }, { "Gd", "Gadolinium" },
            { "Tb", "Terbium" }, { "Dy", "Dysprosium" }, { "Ho", "Holmium" }, { "Er", "Erbium" },
            { "Tm", "Thulium" }, { "Yb", "Ytterbium" }, { "Lu", "Lutetium" }, { "Hf", "Hafnium" },
            { "Ta", "Tantalum" }, { "W", "Tungsten" }, { "Re", "Rhenium" }, { "Os", "Osmium" },
            { "Ir", "Iridium" }, { "Pt", "Platinum" }, { "Au", "Gold" }, { "Hg", "Mercury" },
            { "Tl", "Thallium" }, { "Pb", "Lead" }, { "Bi", "Bismuth" }, { "Po", "Polonium" },
            { "At", "Astatine" }, { "Rn", "Radon" }, { "Fr", "Francium" }, { "Ra", "Radium" },
            { "Ac", "Actinium" }, { "Th", "Thorium" }, { "Pa", "Protactinium" }, { "U", "Uranium" },
            { "Np", "Neptunium" }, { "Pu", "Plutonium" }, { "Am", "Americium" }, { "Cm", "Curium" },
            { "Bk", "Berkelium" }, { "Cf", "Californium" }, { "Es", "Einsteinium" }, { "Fm", "Fermium" },
            { "Md", "Mendelevium" }, { "No", "Nobelium" }, { "Lr", "Lawrencium" }, { "Rf", "Rutherfordium" },
            { "Db", "Dubnium" }, { "Sg", "Seaborgium" }, { "Bh", "Bohrium" }, { "Hs", "Hassium" },
            { "Mt", "Meitnerium" }, { "Ds", "Darmstadtium" }, { "Rg", "Roentgenium" }, { "Cn", "Copernicium" },
            { "Nh", "Nihonium" }, { "Fl", "Flerovium" }, { "Mc", "Moscovium" }, { "Lv", "Livermorium" },
            { "Ts", "Tennessine" }, { "Og", "Oganesson" }, { "Uut", "Ununtrium"}, { "Uup", "Ununpentium"},
            { "Uus", "Ununseptium"}, { "Uuo", "Ununoctium"}
        };

        public static string[][] ElementalForms(string word)
        {
            var result = new List<string[]>();
            if (!string.IsNullOrEmpty(word))
            {
                GetElementalForms(word.ToLower(), 0, new List<string>(), result);
            }
            return result.Count > 0 ? result.ToArray() : new string[0][];
        }

        private static void GetElementalForms(string word, int index, List<string> CurrentElementalForms, List<string[]> result)
        {
            if (index == word.Length)
            {
                result.Add(CurrentElementalForms.ToArray());
                return;
            }

            for (int length = 1; length <= 3; length++)
            {
                if (index + length <= word.Length)
                {
                    string symbol = word.Substring(index, length);
                    if (periodicTable.ContainsKey(symbol.Capitalize()))
                    {
                        var elementName = periodicTable[symbol.Capitalize()];
                        CurrentElementalForms.Add($"{elementName} ({symbol.Capitalize()})");
                        GetElementalForms(word, index + length, CurrentElementalForms, result);
                        CurrentElementalForms.RemoveAt(CurrentElementalForms.Count - 1);
                    }
                }
            }
        }
    }

    public static class StringCapitalization
    {
        public static string Capitalize(this string input)
        {
            if (string.IsNullOrEmpty(input)) {
                return input;
            }

            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}
