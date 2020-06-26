using Bridge;
using Newtonsoft.Json;
using System;
using Bridge.Html5;
using Bridge.Utils;
using System.Globalization;
using System.Diagnostics.Contracts;

namespace ConstructionCalculator
{
    public class App
    {
        public static void Main()
        {
            

            HomeMessurement home = new HomeMessurement();
            home.RoomsQte = rooms;
            home.BathQte = bath;
            home.ClosetQte = closet;
            home.OfficeEx = office;
            home.TheaterEx = theater;
            home.LivingTp = living;
            home.BalconyTp = balcony;
            home.GarageQte = garage;
            home.KitchenTp = kitchen;
            home.PoolTp = pool;
            home.CalculateRooms();
            home.CalculateBath();
            home.CalculateCloset();
            home.CalculateOffice();
            home.CalculateTheater();
            home.CalculateLiving();
            home.CalculateBalcony();
            home.CalculateGarage();
            home.CalculateKitchen();
            home.CalculatePool();
            home.SumPartialArea();
            home.CalculateComplementaryArea();
            home.CalculateTotalArea();
            home.CalculateTerrainPrice();
            home.CalculateConstructionPrice();
            home.CalculateTotalPrice();

            System.Console.WriteLine("Area Parcial " + home.PartialArea.ToString("F2"));
            System.Console.WriteLine("Area Complementar " + home.ComplementaryArea.ToString("F2"));
            System.Console.WriteLine("Area Total " + home.TotalArea.ToString("F2"));
            System.Console.WriteLine("Valor Terreno " + home.TerrainPrice.ToString("F2"));
            System.Console.WriteLine("Valor Construção Complementar " + home.ConstructionPrice.ToString("F2"));
            System.Console.WriteLine("Valor Total " + home.TotalPrice.ToString("F2"));

           
        }



        /* Não gerou interface com usuário
        HomeMessurement home = new HomeMessurement();
        var div = new HTMLDivElement();

        var rooms = new HTMLInputElement()
        {
            Id = "rooms",
            Type = InputType.Number,
            Placeholder = "Número de Quartos (2, 3 ou 4)",
            Style =
                {
                    Margin = "5px"
                }
        };
        var bath = new HTMLInputElement()
        {
            Id = "bath",
            Type = InputType.Number,
            Placeholder = "Número de banheiros (2 a 6)",
            Style =
                {
                    Margin = "5px"
                }
        };
        var closet = new HTMLInputElement()
        {
            Id = "closet",
            Type = InputType.Number,
            Placeholder = "Número de Closets (1 a 4)",
            Style =
                {
                    Margin = "5px"
                }
        };
        var office = new HTMLInputElement()
        {
            Id = "office",
            Type = InputType.Text,
            Placeholder = "Terá escritório (S/N)?",
            Style =
                {
                    Margin = "5px"
                }
        };
        var theater = new HTMLInputElement()
        {
            Id = "theater",
            Type = InputType.Text,
            Placeholder = "Terá Home Theater (S/N)?",
            Style =
                {
                    Margin = "5px"
                }
        };
        var living = new HTMLInputElement()
        {
            Id = "living",
            Type = InputType.Number,
            Placeholder = "Tipo de sala / living? ( 1 , 2 ou 3 )",
            Style =
                {
                    Margin = "5px"
                }
        };
        var balcony = new HTMLInputElement()
        {
            Id = "balcony",
            Type = InputType.Text,
            Placeholder = "Tipo de varanda / area gourmet? ( A , B ou C )",
            Style =
                {
                    Margin = "5px"
                }
        };
        var garage = new HTMLInputElement()
        {
            Id = "garage",
            Type = InputType.Number,
            Placeholder = "Tipo garagem ( 2, 3 ou 4 carros )",
            Style =
                {
                    Margin = "5px"
                }
        };
        var kitchen = new HTMLInputElement()
        {
            Id = "kitchen",
            Type = InputType.Text,
            Placeholder = "Tipo de cozinha ( A ou B )",
            Style =
                {
                    Margin = "5px"
                }
        };
        var pool = new HTMLInputElement()
        {
            Id = "pool",
            Type = InputType.Text,
            Placeholder = "Terá Piscina (N ou modelo  A ou B )",
            Style =
                {
                    Margin = "5px"
                }
        };

        var buttonSave = new HTMLButtonElement()
        {
            Id = "b",
            InnerHTML = "Save"
        };

        var buttonRestore = new HTMLButtonElement()
        {
            Id = "r",
            InnerHTML = "Restore",
            Style =
    {
        Margin = "5px"
    }
        };

        div.AppendChild(rooms);
        div.AppendChild(bath);
        div.AppendChild(closet);
        div.AppendChild(office);
        div.AppendChild(theater);
        div.AppendChild(living);
        div.AppendChild(balcony);
        div.AppendChild(kitchen);
        div.AppendChild(pool);

        div.AppendChild(buttonSave);
        div.AppendChild(buttonRestore);


        */
    }

}
