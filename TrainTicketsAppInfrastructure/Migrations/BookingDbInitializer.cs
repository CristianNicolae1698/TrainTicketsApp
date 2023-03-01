﻿using DomainLibrary.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Migrations
{
    public static class BookingDbInitializer
    {    
        public static void Initialize(BookingContext context)
        {
            context.Database.EnsureCreated();

            //Look for any routes
            if (context.Trains.Any() && context.Stations.Any() && context.Routes.Any())
            {
                return; //DB has been seeded
            }

         
            List<Train> trainList = new List<Train>()
            {
                new Train{Id=Guid.NewGuid(),TrainNumber="123", TrainType="Regio-BucCv"},
                new Train{Id=Guid.NewGuid(),TrainNumber="234", TrainType="InterRegio-BucCv"},
                new Train{Id=Guid.NewGuid(),TrainNumber="345", TrainType="InterCity-BucCv"},
                new Train{Id=Guid.NewGuid(),TrainNumber="456", TrainType="Regio-CtBuc"},
                new Train{Id=Guid.NewGuid(),TrainNumber="567", TrainType="InterRegio-CtBuc"},
                new Train{Id=Guid.NewGuid(),TrainNumber="678", TrainType="InterCity-CtBuc"},
                new Train{Id=Guid.NewGuid(),TrainNumber="789", TrainType="Regio-BvBuc"},
                new Train{Id=Guid.NewGuid(),TrainNumber="901", TrainType="InterRegio-BvBuc"},
                new Train{Id=Guid.NewGuid(),TrainNumber="124", TrainType="InterCity-BvBuc"},
                new Train{Id=Guid.NewGuid(),TrainNumber="421", TrainType="Regio-BvCt"},
                new Train{Id=Guid.NewGuid(),TrainNumber="375", TrainType="InterRegio-BvCt"},
                new Train{Id=Guid.NewGuid(),TrainNumber="753", TrainType="InterCity-BvCt"},
                new Train{Id=Guid.NewGuid(),TrainNumber="357", TrainType="Regio-CtCv"},
                new Train{Id=Guid.NewGuid(),TrainNumber="579", TrainType="InterRegio-CtCv"},
                new Train{Id=Guid.NewGuid(),TrainNumber="246", TrainType="InterCity-CtCv"}
               
            };
            
            foreach(var Train in trainList)
            {
                context.Trains.Add(Train);
            }
            context.SaveChanges();

            List<Station> stationList = new List<Station>()
            {
                new Station{Id=Guid.NewGuid(),StationName="Bucuresti"},
                new Station{Id=Guid.NewGuid(),StationName="Craiova"},
                new Station{Id=Guid.NewGuid(),StationName="Brasov"},
                new Station{Id=Guid.NewGuid(),StationName="Constanta"}

            };
            foreach(var station in stationList)
            {
                context.Stations.Add(station);
            }
            context.SaveChanges();
            var route1 = new Route
            { 
                RouteName = $"{stationList[0].StationName} - {stationList[1].StationName}",
            };
            Station stationArrival1 = context.Stations.First(s => s.StationName == stationList[0].StationName);
            route1.Stations.Add(stationArrival1);
            Station stationDeparture1 = context.Stations.First(s => s.StationName == stationList[1].StationName);
            route1.Stations.Add(stationDeparture1);
            Train train1R1 = context.Trains.First(t => t.TrainType == trainList[0].TrainType);
            route1.Trains.Add(train1R1);
            Train train2R1 = context.Trains.First(t => t.TrainType == trainList[1].TrainType);
            route1.Trains.Add(train2R1);
            Train train3R1 = context.Trains.First(t => t.TrainType == trainList[2].TrainType);
            route1.Trains.Add(train3R1);
            context.Routes.Add(route1);
            context.SaveChanges();
            var route2 = new Route
            {
                RouteName = $"{stationList[3].StationName} - {stationList[0].StationName}",
            };
            Station stationArrival2 = context.Stations.First(s => s.StationName == stationList[3].StationName);
            route2.Stations.Add(stationArrival2);
            Station stationDeparture2 = context.Stations.First(s => s.StationName == stationList[0].StationName);
            route2.Stations.Add(stationDeparture2);
            Train train1R2 = context.Trains.First(t => t.TrainType == trainList[3].TrainType);
            route2.Trains.Add(train1R2);
            Train train2R2 = context.Trains.First(t => t.TrainType == trainList[4].TrainType);
            route2.Trains.Add(train2R2);
            Train train3R2 = context.Trains.First(t => t.TrainType == trainList[5].TrainType);
            route2.Trains.Add(train3R2);
            context.Routes.Add(route2);
            context.SaveChanges();
            var route3 = new Route
            {
                RouteName = $"{stationList[2].StationName} - {stationList[0].StationName}",
            };
            Station stationArrival3 = context.Stations.First(s => s.StationName == stationList[2].StationName);
            route3.Stations.Add(stationArrival3);
            Station stationDeparture3 = context.Stations.First(s => s.StationName == stationList[0].StationName);
            route3.Stations.Add(stationDeparture3);
            Train train1R3 = context.Trains.First(t => t.TrainType == trainList[6].TrainType);
            route3.Trains.Add(train1R3);
            Train train2R3 = context.Trains.First(t => t.TrainType == trainList[7].TrainType);
            route3.Trains.Add(train2R3);
            Train train3R3 = context.Trains.First(t => t.TrainType == trainList[8].TrainType);
            route3.Trains.Add(train3R3);
            context.Routes.Add(route3);
            context.SaveChanges();

            var route4 = new Route
            {
                RouteName = $"{stationList[2].StationName} - {stationList[3].StationName}",
            };
            Station stationArrival4 = context.Stations.First(s => s.StationName == stationList[2].StationName);
            route4.Stations.Add(stationArrival3);
            Station stationDeparture4 = context.Stations.First(s => s.StationName == stationList[0].StationName);
            route4.Stations.Add(stationDeparture3);
            Train train1R4 = context.Trains.First(t => t.TrainType == trainList[9].TrainType);
            route4.Trains.Add(train1R4);
            route2.Trains.Add(train1R4);
            Train train2R4 = context.Trains.First(t => t.TrainType == trainList[10].TrainType);
            route4.Trains.Add(train2R4);
            route2.Trains.Add(train2R4);
            Train train3R4 = context.Trains.First(t => t.TrainType == trainList[11].TrainType);
            route4.Trains.Add(train3R4);
            route2.Trains.Add(train3R4);
            context.Routes.Add(route4);
            context.SaveChanges();

            var route5 = new Route
            {
                RouteName = $"{stationList[3].StationName} - {stationList[1].StationName}",
            };
            Station stationArrival5 = context.Stations.First(s => s.StationName == stationList[2].StationName);
            route5.Stations.Add(stationArrival3);
            Station stationDeparture5 = context.Stations.First(s => s.StationName == stationList[0].StationName);
            route5.Stations.Add(stationDeparture3);
            Train train1R5 = context.Trains.First(t => t.TrainType == trainList[12].TrainType);
            route5.Trains.Add(train1R5);
            Train train2R5 = context.Trains.First(t => t.TrainType == trainList[13].TrainType);
            route5.Trains.Add(train2R5);
            Train train3R5 = context.Trains.First(t => t.TrainType == trainList[14].TrainType);
            route5.Trains.Add(train3R5);
            context.Routes.Add(route5);
            context.SaveChanges();








        }



    }
    
}
